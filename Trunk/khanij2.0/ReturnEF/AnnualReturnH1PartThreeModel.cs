using System;
using System.Collections.Generic;
using System.Text;

namespace ReturnEF
{
    public class AnnualReturnH1PartThreeModel
    {
        public MaterialConsumed objMaterialConsumed { get; set; }
        public RoyaltyandRents objRoyaltyandRents { get; set; }
        public AnnualReturnH1PartThreeModel()
        {
            objMaterialConsumed = new MaterialConsumed();
            objRoyaltyandRents = new RoyaltyandRents();
        }
    }

    public class MaterialConsumed
    {
        public int? MaterialConsumed_Id { get; set; }
        //------------Fuel------------------------
        public string CoalQty { get; set; }
        public string CoalValue { get; set; }
        public string DieselOilQty { get; set; }
        public string DieselOilValue { get; set; }
        public string PetrolQty { get; set; }
        public string PetrolValue { get; set; }
        public string KeroseneQty { get; set; }
        public string KeroseneValue { get; set; }
        public string GasQty { get; set; }
        public string GasValue { get; set; }
        //----------Lubricant---------------------
        public string LubricantoilQty { get; set; }
        public string LubricantoilValue { get; set; }
        public string GreaseQty { get; set; }
        public string GreaseValue { get; set; }
        //----------Electricity--------------------
        public string ConsumedQty { get; set; }
        public string ConsumedValue { get; set; }
        public string GeneratedQty { get; set; }
        public string GeneratedValue { get; set; }
        public string SoldQty { get; set; }
        public string SoldValue { get; set; }
        //----------Explosives---------------------
        public string ExplosivesValue { get; set; }
        //----------Tyres--------------------------
        public string TyresQty { get; set; }
        public string TyresValue { get; set; }
        //----------Timber & Supports--------------  
        public string Timber_SupportsValue { get; set; }
        //----------Drill rods & kits--------------
        public string Drill_kitsQty { get; set; }
        public string Drill_kitsValue { get; set; }
        //----------Other spares & stores----------
        public string OtherSparesValue { get; set; }
        //----------------------------------------
        public string Year { get; set; }
        public int? Flag1 { get; set; }
        public int? UserId { get; set; }
    }

    public class RoyaltyandRents
    {
        public int? RoyaltyandRents_Id { get; set; }
        //------Royalty, Rents and Payments made to DMF & NMET----------        
        public string RoyaltyCurrentyear { get; set; }
        public string RoyaltyArrears { get; set; }
        public string DeadRentCurrentyear { get; set; }
        public string DeadRentArrears { get; set; }
        public string SurfaceRentCurrentyear { get; set; }
        public string SurfaceRentArrears { get; set; }
        public string DMFCurrentyear { get; set; }
        public string DMFArrears { get; set; }
        public string NMETCurrentyear { get; set; }
        public string NMETArrears { get; set; }
        //-------Compensation paid for felling trees during the year (Rs)------
        public string Compensation_Trees { get; set; }
        public string Depreciation { get; set; }
        //-------Taxes and cesses-------------------------------------
        public string SalesTax_CentralGovt { get; set; }
        public string SalesTax_StateGovt { get; set; }
        public string Welfarecess_CentralGovt { get; set; }
        public string Welfarecess_StateGovt { get; set; }
        public string Cess_CentralGovt { get; set; }
        public string Cess_StateGovt { get; set; }

        public string CessdeadRent_CentralGovt { get; set; }
        public string CessdeadRent_StateGovt { get; set; }

        public string Others_CentralGovt { get; set; }
        public string Others_StateGovt { get; set; }
        //-------Other expenses (Rs)------------------
        public string Overheads { get; set; }
        public string Maintenance { get; set; }
        public string Moneyvalue { get; set; }
        public string Paymentmade { get; set; }
        //------------------------------------------
        public string Year { get; set; }
        public int? Flag2 { get; set; }
        public int? UserId { get; set; }
    }
}
