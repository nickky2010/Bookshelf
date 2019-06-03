using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class BookDTO : IEntityDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter book name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter book year")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Enter book ISBN")]
        public string ISBN { get; set; }
        public string Edition { get; set; }
        [Required(ErrorMessage = "Enter the date and time the book was added")]
        public DateTime DateTimeOfAdded { get; set; }
        public float? Width { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        [Required(ErrorMessage = "Enter count book pages")]
        public int Pages { get; set; }
        [Required(ErrorMessage = "Enter book group")]
        public int BookGroup { get; set; }
        [Required(ErrorMessage = "Enter book language")]
        public string Language { get; set; }
        [Required(ErrorMessage = "Enter book publishing house")]
        public string PublishingHouse { get; set; }
        [Required(ErrorMessage = "Enter book series")]
        public string Series { get; set; }
        public ICollection<AuthorDTO> Authors { get; set; }
        public ICollection<GenreDTO> Genres { get; set; }
        public ICollection<TagDTO> Tags { get; set; }
        public BookDTO()
        {
            Authors = new List<AuthorDTO>();
            Genres = new List<GenreDTO>();
            Tags = new List<TagDTO>();
        }
    }
}
