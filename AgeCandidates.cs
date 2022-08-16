using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JsonDeserializeTest
{
    public class AgeCandidates : List<AgeCandidate>
    {
        public int AgePointer = 0;
        public AgeCandidates(AjaxBookGenieParams ajaxParams)
        {
            // TODO: FOr testing ignore class library - not enough
            BuildCandidateList(ajaxParams, 0);
            //BuildCandidateList(ajaxParams.BookGenieParams.CustomerGuid, DataAccessStatic.GetCategoryIdByName(Constants.ClassLibrary));
        }
        // Builds empty one with AgeId = 0
        public AgeCandidates()
        {
            var candidate = new AgeCandidate(0);
            this.Add(candidate);
        }
        
        protected AgeCandidate GetAgeCandidate(int ageId) {
            AgeCandidate returnAgeCandidate = null;
            foreach (var ageCandidate in this)
            {
                if (ageCandidate.AgeId == ageId)
                {
                    returnAgeCandidate = ageCandidate;
                    break;
                }
            }
            // If not exists, create a new one
            if (returnAgeCandidate == null)
            {
                returnAgeCandidate = new AgeCandidate(ageId);
                this.Add(returnAgeCandidate);
            }
            return returnAgeCandidate;
        }
        protected AgeCandidate GetNextAge(int ageId = 0)
        {
            if (this.Count == 0) return null;
            // Manage circular loop
            if (ageId > 0) // force specific age -- if none available - use next
            {
                foreach(var ageCandidate in this)
                {
                    if (ageCandidate.AgeId == ageId)
                    {
                        AgePointer = this.IndexOf(ageCandidate);
                    }
                }
            }
            AgePointer = AgePointer < this.Count ? AgePointer : 0 ;            
            return this[AgePointer++];
        }

        public void RemoveUsedCandidate(AllocationCandidate allocationCandidate, int ageId)
        {
            var ageCandidate = GetNextAge(ageId);
            ageCandidate.AllocationCandidates.Remove(allocationCandidate);
        }

        public AllocationCandidate GetNext(int ageId = 0)
        {
            AllocationCandidate candidate = null;
            AgeCandidate ageCandidate;
                if (this.Count > 0)
                {
                    ageCandidate = GetNextAge(ageId);
                    if (ageCandidate.AllocationCandidates.Count > 0)
                    {
                        candidate = ageCandidate.AllocationCandidates[0];
                        ageCandidate.AllocationCandidates.RemoveAt(0);
                    }
                // remove empty AgeCandidate - if necessary
                if (ageCandidate.AllocationCandidates.Count == 0)
                {
                    this.Remove(ageCandidate);
                }
            }
            return candidate;
        }
        private void BuildCandidateList(AjaxBookGenieParams ajaxParams, int bookGenieCategoryId)
        {
            // First Get All Candidates
            //var selectedAges = ajaxParams.ProductFilterParams.SelectedAges;
            //Removed for Serialize test
            //List<AllocationCandidate> candidates = DataAccessStatic.GetAllocationCandidates(selectedAges, bookGenieCategoryId);

            //foreach (var candidate in candidates)
            //{
            //    //Load candidates only for selected ages 
            //    var ageCandidate = this.GetAgeCandidate( candidate.AgeId.ToNativeInt());

            //    ageCandidate.AllocationCandidates.Add(candidate);
            //}
        }
    }


    public class AgeCandidate
    {
        public int AgeId { get; set; }
        public List<AllocationCandidate> AllocationCandidates = new List<AllocationCandidate>();
        public AgeCandidate(int ageId)
        {
            AgeId = ageId;
        }
   
    }
}
