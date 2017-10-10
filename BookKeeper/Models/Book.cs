using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BookKeeper.Models
{
    [DataContract]
    public class Book
    {
        private const int MinimumStringLength = 1;
        private const int MaximumStringLength = 100;
        private const string StringLengthErrorMessage = "Довжина стрічки повинна бути від 1 до 100 символів";

        private const string MinYear = "0";
        private const string MaxYear = "99999";
        private const string YearErrorMessage = "Ціну можна ввести в діапазоні від " + MinYear + " до " + MaxYear;

        private const string MinPrice = "0";
        private const string MaxPrice = "9999999";
        private const string PriceErrorMessage = "Ціну можна ввести в діапазоні від " + MinPrice + " до " + MaxPrice;

        [DataMember]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DataMember]
        [Display(Name = "Назва книги")]
        [Required(ErrorMessage = "Введіть назву книги")]
        [StringLength(MaximumStringLength, MinimumLength = MinimumStringLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; }

        [DataMember]
        [Display(Name = "Автор")]
        [Required(ErrorMessage = "Введіть ім'я автора")]
        [StringLength(MaximumStringLength, MinimumLength = MinimumStringLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Author { get; set; }

        [DataMember]
        [Display(Name = "Категорія")]
        [Required(ErrorMessage = "Введіть до якої категорії належить книга")]
        [StringLength(MaximumStringLength, MinimumLength = MinimumStringLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Category { get; set; }

        [DataMember]
        [Display(Name = "Опис")]
        [Required(ErrorMessage = "Введіть опис книги")]
        public string Description { get; set; }

        [DataMember]
        [Display(Name = "Рік випуску")]
        [Required(ErrorMessage = "Введіть рік випуску книги")]
        [Range(typeof(int), MinYear, MaxYear, ErrorMessage = YearErrorMessage)]
        public int Year { get; set; }

        [DataMember]
        [Display(Name = "Ціна, грн")]
        [Required(ErrorMessage = "Введіть ціну")]
        [Range(typeof(double), MinPrice, MaxPrice, ErrorMessage = PriceErrorMessage)]
        public double Price { get; set; }

        public object this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case "Id":
                    {
                        return Id;
                    }
                    case "Name":
                    {
                        return Name;
                    }
                    case "Author":
                    {
                        return Author;
                    }
                    case "Category":
                    {
                        return Category;
                    }
                    case "Description":
                    {
                        return Description;
                    }
                    case "Year":
                    {
                        return Year;
                    }
                    case "Price":
                    {
                        return Price;
                    }
                    default:
                        return null;
                }
            }
        }
    }
}