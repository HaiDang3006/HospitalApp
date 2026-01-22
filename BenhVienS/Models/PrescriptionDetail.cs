using System;

namespace Hospital.Models
{
    public class PrescriptionDetail
    {
        // Properties of PrescriptionDetail
        public int PrescriptionDetailId { get; set; }   // Prescription detail ID
        public int PrescriptionId { get; set; }         // Prescription ID
        public int MedicineId { get; set; }              // Medicine ID
        public int Quantity { get; set; }                // Quantity of medicine
        public decimal UnitPrice { get; set; }           // Unit price of the medicine
        public string UsageInstructions { get; set; }    // Usage instructions for the medicine
        public string Morning { get; set; }              // Morning
        public string Noon { get; set; }                 // Noon
        public string Afternoon { get; set; }            // Afternoon
        public string Evening { get; set; }              // Evening
        public bool BeforeMeal { get; set; }             // Before meal
        public bool AfterMeal { get; set; }              // After meal
        public int DaysOfUse { get; set; }               // Number of days to use the medicine
        public decimal TotalAmount { get; set; }         // Total amount

        // Parameterless constructor
        public PrescriptionDetail() { }

        // Full constructor
        public PrescriptionDetail(int prescriptionDetailId, int prescriptionId, int medicineId, int quantity, decimal unitPrice, string usageInstructions,
            string morning, string noon, string afternoon, string evening, bool beforeMeal, bool afterMeal, int daysOfUse, decimal totalAmount)
        {
            PrescriptionDetailId = prescriptionDetailId;
            PrescriptionId = prescriptionId;
            MedicineId = medicineId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            UsageInstructions = usageInstructions;
            Morning = morning;
            Noon = noon;
            Afternoon = afternoon;
            Evening = evening;
            BeforeMeal = beforeMeal;
            AfterMeal = afterMeal;
            DaysOfUse = daysOfUse;
            TotalAmount = totalAmount;
        }
    }
}
