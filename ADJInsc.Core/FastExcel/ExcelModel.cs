namespace ADJInsc.Core.FastExcel
{
    using System;

    public class ExcelModel
    {
        public string Estado { get; set; }
        public int IdPP { get; set; }
        public string MontoBruto { get; set; }
        public string Monto { get; set; }
        public int MedioPago { get; set; }
        public DateTime Fecha { get; set; }
        public Guid IdComercio { get; set; }
        public string Informacion { get; set; }
        public string FechaLiquidacion { get; set; }       

    }
}
