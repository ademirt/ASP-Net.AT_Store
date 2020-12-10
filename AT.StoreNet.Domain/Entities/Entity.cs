﻿using System;

namespace AT.StoreNet.Domain.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime DtCadastro { get; set; }

        public Entity()
        {
            DtCadastro = DateTime.Now;
        }
    }
}