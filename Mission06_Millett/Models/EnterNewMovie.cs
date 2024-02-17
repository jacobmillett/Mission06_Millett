namespace Mission06_Millett.Models
{
    using System.ComponentModel.DataAnnotations;
    public class EnterNewMovie
    {
        // This is the form where I have all of the fields that need to be entered. Some are required others are not. MovieID autoincrements.
        [Key]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public required string Category { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public required int Year { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public required string Director { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public  required string Rating { get; set; }
        public bool Edited { get; set; }
        public string? Lent { get; set; }

        public string? Notes { get; set; }

    }
}
