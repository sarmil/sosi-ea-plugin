﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arkitektum.Kartverket.SOSI.Model
{
    public abstract class AbstraktEgenskap
    {
        public string UML_Navn { get; set; }

        private string _sosiNavn;

        public string SOSI_Navn
        {
            get { return _sosiNavn; }
            set { _sosiNavn = value.Trim(); }
        }

        public string Standard { get; set; }
        public string Multiplisitet { get; set; }

        public string Notat { get; set; }

        public void FiksMultiplisitet()
        {
            Multiplisitet = Multiplisitet.Replace("[0]", "[0..1]");
            Multiplisitet = Multiplisitet.Replace("[0..]", "[0..*]");
            Multiplisitet = Multiplisitet.Replace("[1..]", "[1..*]");
            Multiplisitet = Multiplisitet.Replace("[1]", "[1..1]");
        }

        public bool ErAssosiasjonSomBeskriverAvgrensning()
        {
            if (string.IsNullOrEmpty(UML_Navn))
                return false;

            return UML_Navn.StartsWith("avgrensesav", StringComparison.OrdinalIgnoreCase) &&
                   UML_Navn.EndsWith("(rolle)", StringComparison.OrdinalIgnoreCase);
        }
    }
}
