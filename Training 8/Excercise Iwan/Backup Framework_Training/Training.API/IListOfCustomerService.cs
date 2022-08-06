using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataModel.TrainingModel;

namespace Training.API
{
    public interface IListOfCustomerService
    {
        List<Cust> listOfCust();
        Cust GetCustById(Int64 custId);
        CustAddr GetCustAddrById(Int64 custAddrId);
        void DeleteListOfCust(Int64 custId);
        void AddListOfCust(Cust cust);
        void EditListOfCust();
        ProdTrxD GetProdTrxDById(Int64 prodTrxDId);
        ProdTrxH GetProdTrxHById(Int64 prodTrxHId);
        ProductD GetProductDById(Int64 productDId);
        ProductH GetProductHById(Int64 productHId);
        void AddListOfProdTrxD(ProdTrxD prodTrxD);
        void EditListOfProdTrxD();
        void AddListOfProdTrxH(ProdTrxH prodTrxH);
        void EditListOfProdTrxH();
        void AddListOfProductD(ProductD productD);
        void EditListOfproductD();
        void AddListOfProductH(ProductH productH);
        void EditListOfproductH();
    }
}
