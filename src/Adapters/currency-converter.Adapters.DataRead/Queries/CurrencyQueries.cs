namespace currency_converter.Adapters.DataRead.Queries
{
    public class CurrencyQueries
    {
        public static string GetConvertedAmount = @"select r.Value
                                                      from Currency c
                                                      left join Rate r on c.Id = r.CurrencyId
                                                      where c.Code = @from
                                                        and r.Code = @to 
                                                      order by r.InsertDate desc";

        public static string GetCurrency = @"select *
                                                from Currency c
                                                left join Rate r on c.Id = r.CurrencyId
                                                where c.Code = @code
                                                order by r.InsertDate desc";
    }
}
