using System.ComponentModel.DataAnnotations;

namespace LolExplorer.Modele
{
    public class ItemApiModel
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The display name must not exceed 50 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The description must not exceed 500 characters.")]
        [RegularExpression(@"^[a-z''-'\s]{1,40}$", ErrorMessage = "Only lowercase characters are accepted.")]
        public string Plaintext { get; set; }
        [Required(ErrorMessage = "The image of the item is mandatory!")]
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
        [Range(typeof(bool), "true", "false", ErrorMessage = "You must decide if its pruchisible or not.")]
        public bool Purchasable { get; set; }
        
    }
}
