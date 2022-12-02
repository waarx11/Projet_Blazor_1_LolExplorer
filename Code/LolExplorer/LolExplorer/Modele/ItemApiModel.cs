using System.ComponentModel.DataAnnotations;

namespace LolExplorer.Modele
{
    public class ItemApiModel
    {

        [Required]
        [StringLength(50, ErrorMessage = "The display name must not exceed 50 characters.")]
        public string name { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The description must not exceed 500 characters.")]
        [RegularExpression(@"^[a-z''-'\s]{1,40}$", ErrorMessage = "Only lowercase characters are accepted.")]
        public string plaintext { get; set; }
        [Required(ErrorMessage = "The image of the item is mandatory!")]
        public byte[] icon { get; set; }
        [Required]
        [Range(1, 125)]
        public int @base { get; set; }
        [Required]
        [Range(1, 125)]
        public int total { get; set; }
        [Required]
        [Range(1, 125)]
        public int sell { get; set;}
        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must decide if its pruchisible or not.")]
        public bool purchasable { get; set; }


        
    }
}
