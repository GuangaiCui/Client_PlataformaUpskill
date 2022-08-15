﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaUpskill_API.Data.Models
{
    public class Turma
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataInicioCurso { get; set; }
        public DateTime? DataFimCurso { get; set; }
        public DateTime? HorarioAssincronoInicio { get; set; }
        public DateTime? HorarioAssincronoFim { get; set; }
        public DateTime? HorarioSincronoInicio { get; set; }
        public DateTime? HorarioSincronoFim { get; set; }
       /*
        public double CargaHoraria
        {
            get
            {
                double cargaHorariaSincrono = (HorarioSincronoFim.Value.TimeOfDay - HorarioSincronoInicio.Value.TimeOfDay).TotalHours;
                double cargaHorarioAssincrono = (HorarioAssincronoFim.Value.TimeOfDay - HorarioAssincronoInicio.Value.TimeOfDay).TotalHours;

                return cargaHorariaSincrono + cargaHorarioAssincrono;
            }
            private set { }
        }
       */
        public int TempoLectivo { get; set; }
        public int? CursoId { get; set; }
        public virtual Curso Curso { get; set; }
        /*
        public List<Aula> Aulas { get; set; } = new List<Aula>();
        public List<Formando> Formandos { get; set; } = new List<Formando>();

        public List<Modulo> Modulos { get; set; } = new List<Modulo>();
        */
    }
}
 