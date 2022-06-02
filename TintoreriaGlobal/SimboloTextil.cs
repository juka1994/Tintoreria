namespace TintoreriaGlobal
{
    public class SimboloTextil : Usuario
    {
        public int Id { get; set; }
        public int IdTipoSimboloRopa { get; set; }
        public string DescripcionSimboloRopa { get; set; }
        public string Descripcion { get; set; }
        public string ImagenBase64 { get; set; }
        public string Extension { get; set; }
        public bool ImagenModificada { get; set; }
    }
}