namespace Simulador.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Datos")]
    public partial class Dato
    {
        public int Id { get; set; }

        [Display(Name = "Capacidad maxima del tanque")]
        [Required(ErrorMessage = "Capacidad maxima del tanque no puede ser vacia")]
        [RegularExpression(@"^[1-9][0-9]?$|^100$", ErrorMessage = "Solo n�meros del 1 al 100")]
        public float cap_max_tanque { get; set; }


        [Display(Name = "Temperatura inicial del tanque")]
        [Required(ErrorMessage = "Temperatura inicial del tanque no puede ser vacia")]
        [RegularExpression(@"^[1-9][0-9]?$|^100$", ErrorMessage = "Solo n�meros del 1 al 100")]
        public float temp_inicial_tanque { get; set; }

 
        [Display(Name = "Material del tanque")]
        [Required(ErrorMessage = "Temperatura inicial del tanque no puede ser vacia")]
        [StringLength(10)]
        public string material_tanque { get; set; }


        [Display(Name = "Resistencia en watts")]
        [Required(ErrorMessage = "Resistencia en watts no puede ser vacia")]
        public int resistencia_watts { get; set; }


        [Display(Name = "Cantidad en ML/Segundos")]
        [Required(ErrorMessage = "Cantidad en ML/Segundos no puede ser vacia")]
        [StringLength(10)]
        public string cant_ml_s { get; set; }

        [Display(Name = "Cantidad en ML inicial")]
        [Required(ErrorMessage = "Cantidad en ML inicial no puede ser vacia")]
        [StringLength(10)]
        public string cant_ml_incial { get; set; }


    }
}