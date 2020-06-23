// File:    SpecialtyType.cs
// Author:  Igorr
// Created: Saturday, April 4, 2020 10:20:10 PM
// Purpose: Definition of Enum SpecialtyType

using System;
using System.ComponentModel;

namespace Model.Users
{
    public enum SpecialtyType
    {
        [Description("General")]
        general,
        [Description("Cardiovascular")]
        cardiovascular,
        [Description("Dermatological")]
        dermatological,
        [Description("Otolaryngological")]
        otolaryngological,
        [Description("Oncological")]
        oncological,
        [Description("Neurological")]
        neurological
    }

    // Helper funkcija za .ToString() enumeracije, koristi se u formatu SpecialtyTypeExtensions.ToFriendlyString(specialtyType)
    public static class SpecialtyTypeExtensions
    {
        public static string ToFriendlyString(this SpecialtyType me)
        {
            switch (me)
            {
                case SpecialtyType.general:
                    return "General";
                case SpecialtyType.cardiovascular:
                    return "Cardiovascular";
                case SpecialtyType.dermatological:
                    return "Dermatological";
                case SpecialtyType.otolaryngological:
                    return "Otolaryngological";
                case SpecialtyType.oncological:
                    return "Oncological";
                case SpecialtyType.neurological:
                    return "Cardiovascular";
                default:
                    return "SpecialtyType default";
            }
        }
    }
}