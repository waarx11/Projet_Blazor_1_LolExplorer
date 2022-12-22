using System.ComponentModel.DataAnnotations;

namespace LolExplorer.Modele
{
    public class ItemApiModel
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The display name must not exceed 500 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The description must not exceed 500 characters.")]
        public string Plaintext { get; set; }
       
        public byte[] Icon { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public int Base { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Total { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Sell { get; set;}
        [Required]
        public bool Purchasable { get; set; } = true;
        public List<string> Tags { get; set; } = new(); 

    }
}
