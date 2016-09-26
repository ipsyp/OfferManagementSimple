﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagement.BusinessModel
{
    public class OfferSearchFilters : BaseSearchFilters<Offer>
    {
        public List<enOfferStatus> OfferStatuses { get; set; }
        public List<int?> OfferID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public List<DateTime?> SubmissionDate { get; set; }
        public List<DateTime?> EvaluationDate { get; set; }        

        public override Imis.Domain.EF.Search.Criteria<Offer> GetExpression()
        {
            var expression = Imis.Domain.EF.Search.Criteria<Offer>.Empty;

            if (OfferStatuses != null && OfferStatuses.Count != 0)
                expression = expression.InMultiSet(x => x.OfferStatusInt, OfferStatuses.Select(x => (int)x));

            var offerIDFrom = OfferID[0];
            if (offerIDFrom.HasValue)
                expression = expression.Where(x => x.ID, offerIDFrom, Imis.Domain.EF.Search.enCriteriaOperator.GreaterThanEquals);

            var offerIDTo = OfferID[1];
            if (offerIDTo.HasValue)
                expression = expression.Where(x => x.ID, offerIDTo, Imis.Domain.EF.Search.enCriteriaOperator.LessThanEquals);

            if (!string.IsNullOrEmpty(Code))
                expression = expression.Where(x => x.Code, Code);

            if (!string.IsNullOrEmpty(Title))
                expression = expression.Where(x => x.Title, Title, Imis.Domain.EF.Search.enCriteriaOperator.Like);

            var submissionDateFrom = SubmissionDate[0];
            if (submissionDateFrom.HasValue)
                expression = expression.Where(x => x.SubmittedAt, submissionDateFrom, Imis.Domain.EF.Search.enCriteriaOperator.GreaterThanEquals);

            var submissionDateTo = SubmissionDate[1];
            if (submissionDateTo.HasValue)
                expression = expression.Where(x => x.SubmittedAt, submissionDateTo, Imis.Domain.EF.Search.enCriteriaOperator.LessThanEquals);

            var evaluationDateFrom = EvaluationDate[0];
            if (evaluationDateFrom.HasValue)
                expression = expression.Where(x => x.EvaluatedAt, evaluationDateFrom, Imis.Domain.EF.Search.enCriteriaOperator.GreaterThanEquals);

            var evaluationDateTo = EvaluationDate[1];
            if (evaluationDateTo.HasValue)
                expression = expression.Where(x => x.EvaluatedAt, evaluationDateTo, Imis.Domain.EF.Search.enCriteriaOperator.LessThanEquals);

            return string.IsNullOrEmpty(expression.CommandText) ? null : expression;
        }
    }
}
