//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    
    public partial class RoomsInfo
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string AccommodationAddress { get; set; }
        public string City { get; set; }
        public System.DateTime StartRent { get; set; }
        public System.DateTime EndRent { get; set; }
        public Nullable<int> UsersInfoId { get; set; }
    
        public virtual UsersInfo UsersInfo { get; set; }
    }
}
