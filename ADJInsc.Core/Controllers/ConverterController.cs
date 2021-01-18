using System;
using System.Collections.Generic;
using System.IO;

using ADJInsc.Core.FastExcel;
using ADJInsc.Core.Helper;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ADJInsc.Core.Controllers
{
    public class ConverterController : Controller
    {
        public IConfiguration Configuration { get; }
        public string _connectionString { get; set; }
        
        private readonly InscripcionHelper apiAservice;

        public ConverterController(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = Configuration["ConnectionStrings:DefaultConnection"];
           
            this.apiAservice = new InscripcionHelper(_connectionString);
        }


        public ActionResult Index()
        {
            var model = new List<FastExcel.ExcelModel>();
            return View(model);
        }      

        // POST: ConverterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IFormCollection form)
        {
            try
            {
            string fileName = "pptotal1.xlsx";

                var cont = 0;
                var modelo = new List<ExcelModel>();
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {

                        while (reader.Read()) //Each row of the file
                        {
                            if (cont == 0)
                            {
                                cont += 1;
                            }
                            else
                            {
                                int.TryParse(reader.GetValue(1).ToString(), out int dato);
                                var fechaCorrecta = reader.GetValue(9).ToString().Replace("hs", string.Empty);
                                var codigoPago = 0;
                                if (reader.GetValue(8).ToString().Contains("Debito") || reader.GetValue(8).ToString().Contains("DEBIN"))  //DEBIN
                                {
                                    codigoPago = 9;
                                }
                                else
                                {           
                                    codigoPago = 8;
                                }
                                if (reader.GetValue(0).ToString().Trim() == "REALIZADA")
                                {
                                    modelo.Add(new ExcelModel
                                    {
                                        Estado = reader.GetValue(0).ToString(),
                                        IdPP = dato,
                                        MontoBruto = reader.GetValue(4).ToString(),
                                        Monto = reader.GetValue(6).ToString(),
                                        MedioPago = codigoPago,
                                        Fecha = DateTime.Parse(fechaCorrecta.Trim()),
                                        IdComercio = new Guid(reader.GetValue(10).ToString()),
                                        Informacion = reader.GetValue(12).ToString(),
                                        FechaLiquidacion = string.Empty

                                    });
                                }
                              
                            }

                        }
                    }
                }

                var result = apiAservice.InsertDB(modelo);

                            return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

       
    }
}
