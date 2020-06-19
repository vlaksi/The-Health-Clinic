// File:    Medicine.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 10:18:00 PM
// Purpose: Definition of Class Medicine

using System;

namespace Model.Medicine
{
   public class Medicine
   {
      private int id;
      private string name;
      private string manufacturer;
      private System.DateTime expirationDate;
      private int quantity;
      
      public int Id
      {
         get
         {
            return id;
         }
         set
         {
            this.id = value;
         }
      }
      
      public string Name
      {
         get
         {
            return name;
         }
         set
         {
            this.name = value;
         }
      }
      
      public string Manufacturer
      {
         get
         {
            return manufacturer;
         }
         set
         {
            this.manufacturer = value;
         }
      }
      
      public System.DateTime ExpirationDate
      {
         get
         {
            return expirationDate;
         }
         set
         {
            this.expirationDate = value;
         }
      }
      
      public int Quantity
      {
         get
         {
            return quantity;
         }
         set
         {
            this.quantity = value;
         }
      }
      
      public int price
      {
         get
         {
            throw new NotImplementedException();
         }
         set
         {
            throw new NotImplementedException();
         }
      }
      
      public System.Collections.Generic.List<Alergen> alergen;
      
      /// <summary>
      /// Property for collection of Alergen
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Alergen> Alergen
      {
         get
         {
            if (alergen == null)
               alergen = new System.Collections.Generic.List<Alergen>();
            return alergen;
         }
         set
         {
            RemoveAllAlergen();
            if (value != null)
            {
               foreach (Alergen oAlergen in value)
                  AddAlergen(oAlergen);
            }
         }
      }
      
      /// <summary>
      /// Add a new Alergen in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddAlergen(Alergen newAlergen)
      {
         if (newAlergen == null)
            return;
         if (this.alergen == null)
            this.alergen = new System.Collections.Generic.List<Alergen>();
         if (!this.alergen.Contains(newAlergen))
            this.alergen.Add(newAlergen);
      }
      
      /// <summary>
      /// Remove an existing Alergen from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveAlergen(Alergen oldAlergen)
      {
         if (oldAlergen == null)
            return;
         if (this.alergen != null)
            if (this.alergen.Contains(oldAlergen))
               this.alergen.Remove(oldAlergen);
      }
      
      /// <summary>
      /// Remove all instances of Alergen from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllAlergen()
      {
         if (alergen != null)
            alergen.Clear();
      }
      public System.Collections.Generic.List<Ingredient> ingredient;
      
      /// <summary>
      /// Property for collection of Ingredient
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Ingredient> Ingredient
      {
         get
         {
            if (ingredient == null)
               ingredient = new System.Collections.Generic.List<Ingredient>();
            return ingredient;
         }
         set
         {
            RemoveAllIngredient();
            if (value != null)
            {
               foreach (Ingredient oIngredient in value)
                  AddIngredient(oIngredient);
            }
         }
      }
      
      /// <summary>
      /// Add a new Ingredient in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddIngredient(Ingredient newIngredient)
      {
         if (newIngredient == null)
            return;
         if (this.ingredient == null)
            this.ingredient = new System.Collections.Generic.List<Ingredient>();
         if (!this.ingredient.Contains(newIngredient))
            this.ingredient.Add(newIngredient);
      }
      
      /// <summary>
      /// Remove an existing Ingredient from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveIngredient(Ingredient oldIngredient)
      {
         if (oldIngredient == null)
            return;
         if (this.ingredient != null)
            if (this.ingredient.Contains(oldIngredient))
               this.ingredient.Remove(oldIngredient);
      }
      
      /// <summary>
      /// Remove all instances of Ingredient from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllIngredient()
      {
         if (ingredient != null)
            ingredient.Clear();
      }
      public SpecialtyType specialtyType;
      public MedicineStatus medicineStatus;
   
   }
}