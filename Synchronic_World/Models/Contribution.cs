//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Synchronic_World.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contribution
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public int EventId { get; set; }
        public int type { get; set; }
    
        public virtual Event contributionEvent { get; set; }
        public virtual User User { get; set; }
    }
}
