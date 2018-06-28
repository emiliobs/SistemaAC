namespace SistemaAC.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public byte Creditos { get; set; }
        public byte Horas { get; set; }
        public decimal Costo { get; set; }
        public bool Estado { get; set; } = true;  

        //Relacion
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}