﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace metaenlace_citas_medicas.Entities
{
    public class Usuario
    {
        [Key]
        public int userID { get; set; }

        public string usuario { get; set; }

        public string nombre { get; set; }

        public string apellidos { get; set; }

        public string clave { get; set; }


    }
}
