using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionLab
{
    #region Basic
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //       // Basic();
    //     //  BasicByTree();
    //        //BasicConstant();
    //        //BasicLessThan();
    //        //BasicLabelTarget();
    //        BasicBlock();
    //        //BasicParseLamba();
    //        //BasicExcutePower();
    //        Console.Read();
    //    }

    //    private static void Basic()
    //    {
    //        Console.WriteLine("");
    //        Console.WriteLine("Basic");
    //        Expression<Func<int, bool>> lambda = num => num > 10;
    //        Console.WriteLine(lambda.Body);//運算式主體 n*n
    //        Console.WriteLine(lambda.Parameters[0]);//參數
    //        Console.WriteLine(lambda.NodeType);//節點型別
    //        Console.WriteLine(lambda.ReturnType);//回傳型別
    //        Console.WriteLine(lambda.Compile()(10));//建置後執行
    //    }
    //    private static void BasicByTree()
    //    {
    //        Console.WriteLine("");
    //        Console.WriteLine("BasicByTree");
    //        ParameterExpression num = Expression.Parameter(typeof(int), "n");
    //        Expression<Func<int, int>> expr =
    //            Expression<Func<int, int>>.Lambda<Func<int, int>>(//建立Lambda方法
    //                Expression.Multiply(num, num)//建立一個num*num的主體
    //                , new ParameterExpression[] { num }//此主體方法為傳入一個num參數
    //              );
    //        Console.WriteLine(expr.Body);
    //        Console.WriteLine(expr.Parameters[0]);
    //        Console.WriteLine(expr.NodeType);
    //        Console.WriteLine(expr.ReturnType);
    //        Console.WriteLine(expr.Compile()(10));
    //    }
    //    private static void BasicConstant()
    //    {
    //        Console.WriteLine("");
    //        Console.WriteLine("BasicConstant");
    //        ParameterExpression numPar = Expression.Parameter(typeof(int), "n");
    //        ConstantExpression five = Expression.Constant(5);
    //        Expression<Func<int, bool>> expr = Expression<Func<int, bool>>.Lambda<Func<int, bool>>(Expression.Equal(numPar, five), new ParameterExpression[] { numPar });
    //        Console.WriteLine(expr.Body);
    //        Console.WriteLine(expr.Parameters[0]);
    //        Console.WriteLine(expr.NodeType);
    //        Console.WriteLine(expr.ReturnType);
    //        Console.WriteLine(expr.Compile()(10));
    //    }
    //    private static void BasicLessThan()
    //    {
    //        ParameterExpression numParm = Expression.Parameter(typeof(int), "num");
    //        ConstantExpression five = Expression.Constant(5, typeof(int));
    //        BinaryExpression numLessThanFive = Expression.LessThan(numParm, five);
    //        Expression<Func<int, bool>> expr = Expression.Lambda<Func<int, bool>>(numLessThanFive, numParm);
    //        Console.WriteLine("");
    //        Console.WriteLine("BasicLessThan");
    //        Console.WriteLine(expr.Body);
    //        Console.WriteLine(expr.Parameters[0]);
    //        Console.WriteLine(expr.NodeType);
    //        Console.WriteLine(expr.ReturnType);
    //        Console.WriteLine(expr.Compile()(20));
    //    }
    //    private static void BasicLabelTarget()
    //    {
    //        LabelTarget returnTarget = Expression.Label();

    //        // This block contains a GotoExpression that represents a return statement with no value.
    //        // It transfers execution to a label expression that is initialized with the same LabelTarget as the GotoExpression.
    //        // The types of the GotoExpression, label expression, and LabelTarget must match.
    //        BlockExpression blockExpr =
    //            Expression.Block(
    //                Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("GoTo")),
    //                Expression.Goto(returnTarget),
    //            //Other Work不會被執行，因為Goto會跳到下下一行
    //                Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("Other Work")),
    //                Expression.Label(returnTarget),
    //                Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("Label Work"))
    //            );

    //        // The following statement first creates an expression tree,
    //        // then compiles it, and then runs it.
    //        Expression.Lambda<Action>(blockExpr).Compile()();
    //    }
    //    private static void BasicBlock()
    //    {
    //        ParameterExpression value = Expression.Parameter(typeof(int), "value");
    //        ParameterExpression result = Expression.Parameter(typeof(int), "result");
    //        LabelTarget label = Expression.Label(typeof(int));
    //        BlockExpression block = Expression.Block(//建立方法區塊
    //            new[] { result },//指定方法的參數為result
    //            Expression.Assign(result, Expression.Constant(1)),//設定變數result=1
    //            Expression.Loop(//建立Loop迴圈區塊
    //                 Expression.IfThenElse(//建立判斷式區塊
    //                        Expression.GreaterThan(value, Expression.Constant(1)),//條件:參數大於5
    //                        Expression.MultiplyAssign(result, Expression.PostDecrementAssign(value)),//true:執行乘法運算並將結果給result 例:result*=value
    //                        Expression.Break(label, result)//false:跳離Loop並到下方的label
    //                        )
    //                        , label//指定標籤，讓上方的Break跳到此行用
    //            )
    //            );
    //        var lamba = Expression.Lambda<Func<int, int>>(block, value);//將方法區塊指定成Lamdba運算式
    //        int factorial = lamba.Compile()(5);
    //        Console.WriteLine(lamba);
    //        Console.WriteLine(factorial);
    //    }
    //    private static void BasicParseLamba()
    //    {
    //        Expression<Func<int, bool>> lamba = num => num < 5;
    //        ParameterExpression param = (ParameterExpression)lamba.Parameters[0];
    //        BinaryExpression operation = (BinaryExpression)lamba.Body;
    //        ParameterExpression left = (ParameterExpression)operation.Left;
    //        ConstantExpression right = (ConstantExpression)operation.Right;
    //        Console.WriteLine("BasicParseLamba: {0} => {1} {2} {3}",
    //              param.Name, left.Name, operation.NodeType, right.Value);
    //    }

    //    private static void BasicExcutePower()
    //    {
    //        BinaryExpression be = Expression.Power(Expression.Constant(2D), Expression.Constant(3D));
    //        Expression<Func<double>> lamba = Expression.Lambda<Func<double>>(be);
    //        double result = lamba.Compile()();
    //        Console.WriteLine("BasicExcutePower:" + result); ;
    //    }
    //}
    #endregion

    #region Second
    //class SecondProgram
    //{
    //    //示範如何將運算式為&&抽換成||
    //    //http://msdn.microsoft.com/zh-tw/library/bb546136.aspx
    //    public class AndAlsoModifier : ExpressionVisitor
    //    {
    //        public Expression Modify(Expression expression)
    //        {
    //            return Visit(expression);
    //        }

    //        protected override Expression VisitBinary(BinaryExpression node)
    //        {
    //            if (node.NodeType == ExpressionType.AndAlso)
    //            {
    //                Expression left = this.Visit(node.Left);//以遞迴方式繼續巡覽
    //                Expression right = this.Visit(node.Right);
    //                return Expression.MakeBinary(ExpressionType.OrElse, left, right, node.IsLiftedToNull, node.Method);
    //            }

    //            return base.VisitBinary(node);
    //        }

    //    }

    //    static void Main(string[] args)
    //    {
    //        Expression<Func<string, bool>> expr = name => name.Length > 10 && name.StartsWith("G");
    //        AndAlsoModifier treeModifier = new AndAlsoModifier();
    //        Expression modifiedExpr = treeModifier.Modify(expr);
    //        Console.WriteLine("修改前:" + expr);
    //        Console.WriteLine("修改後:" + modifiedExpr);
    //        Console.Read();
    //    }
    //}
    #endregion

    #region DynamicQuery
    class DynamicQueryProgram
    {
        static void Main(string[] args)
        {
            DynamicQuery();
            Console.Read();
        }
        private static void DynamicQuery()
        {
            string sortColumn = "ProductName";
            string filterColumn = "CategoryName";
            string filterValue = "HTC";
            IQueryable<ProductModel> data = ProductModel.GetDatas();
            data = OrderBy(data, sortColumn);
            data = Where(data, filterColumn, filterValue);
            foreach (var item in data)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        private static void TraditionQuery()
        {
            string sortColumn = "ProductName";
            string filterColumn = "CategoryName";
            string filterValue = "HTC";
            IQueryable<ProductModel> data = ProductModel.GetDatas();
            switch (sortColumn)
            {
                case "CategoryName":
                    data = data.OrderBy(m => m.CategoryName);
                    break;
                case "ProductName":
                    data = data.OrderBy(m => m.ProductName);
                    break;
            }

            switch (filterColumn)
            {
                case "CategoryName":
                    data = data.Where(m => m.CategoryName == filterValue);
                    break;
                case "ProductName":
                    data = data.Where(m => m.ProductName == filterValue);
                    break;
            }

        }



        private static IQueryable<ProductModel> OrderBy(IQueryable<ProductModel> source, string sortColumn)
        {
            //傳入參數 如:m
            ParameterExpression pe = Expression.Parameter(source.ElementType, "m");
            //回傳欄位 如:m.ProductName
            Expression sortExp = Expression.Property(pe, typeof(ProductModel).GetProperty(sortColumn));
            //Lamba運算式 如:m=>m.ProductName
            Expression body = Expression.Lambda<Func<ProductModel, string>>(sortExp, new ParameterExpression[] { pe });
            //呼叫OrderBy方法
            MethodCallExpression OrderByCallExpression = Expression.Call(
                            typeof(Queryable),//來源型別
                            "OrderBy",//指定方法名稱
                            new Type[] { typeof(ProductModel), typeof(string) },//body lamba使用到Expression型別，例:sortExp及pe
                            source.Expression,//來源運算式
                            body);
            var result = (IQueryable<ProductModel>)source.Provider.CreateQuery(OrderByCallExpression);
            return result;
        }

        private static IQueryable<ProductModel> Where(IQueryable<ProductModel> source, string filterColumn, string filterValue)
        {
            //傳入參數 如:m
            ParameterExpression pe = Expression.Parameter(source.ElementType, "m");
            //回傳欄位 如:m.CategoryName
            Expression filterExp = Expression.Property(pe, typeof(ProductModel).GetProperty(filterColumn));
            //條件值 如:"HTC"
            ConstantExpression valueExp = Expression.Constant(filterValue, typeof(string));
            //等於條件主體 如:m.CategoryName=="HTC"
            Expression predicateBody = Expression.Equal(filterExp, valueExp);
            //Lamba運算式 
            Expression body = Expression.Lambda<Func<ProductModel, bool>>(predicateBody, new ParameterExpression[] { pe });
            //呼叫Where方法
            MethodCallExpression whereCallExpression = Expression.Call(
                            typeof(Queryable),//來源型別
                            "Where",//指定方法名稱
                            new Type[] { typeof(ProductModel) },//body lamba使用到Expression型別，例:pe
                            source.Expression,//來源運算式
                            body);
            var result = (IQueryable<ProductModel>)source.Provider.CreateQuery(whereCallExpression);
            return result;
        }

    }

    public class ProductModel
    {
        public int ProductId { get; set; }

        public string CategoryName { get; set; }

        public string ProductName { get; set; }

        public int Qty { get; set; }

        public double Price { get; set; }

        public DateTime CreateDate { get; set; }

        public bool OnSaled { get; set; }

        public static IQueryable<ProductModel> GetDatas()
        {

            List<ProductModel> data = new List<ProductModel>();
            data.Add(new ProductModel { CategoryName = "Apple", ProductId = 1, ProductName = "iPhone3", Price = 5000, Qty = 5, CreateDate = new DateTime(2009, 1, 1) });
            data.Add(new ProductModel { CategoryName = "Apple", ProductId = 2, ProductName = "iPhone4", Price = 10000, Qty = 6, CreateDate = new DateTime(2010, 3, 1) });
            data.Add(new ProductModel { CategoryName = "Apple", ProductId = 3, ProductName = "iPhone4s", Price = 15000, Qty = 15, CreateDate = new DateTime(2011, 4, 1) });
            data.Add(new ProductModel { CategoryName = "Apple", ProductId = 4, ProductName = "iPhone5", Price = 20000, Qty = 25, CreateDate = new DateTime(2012, 5, 1), OnSaled = true });
            data.Add(new ProductModel { CategoryName = "Apple", ProductId = 5, ProductName = "iPhone5s", Price = 25000, Qty = 5, CreateDate = new DateTime(2013, 6, 8), OnSaled = true });

            data.Add(new ProductModel { CategoryName = "HTC", ProductId = 6, ProductName = "Diamond", Price = 5000, Qty = 5, CreateDate = new DateTime(2009, 1, 1) });
            data.Add(new ProductModel { CategoryName = "HTC", ProductId = 7, ProductName = "Titan", Price = 6000, Qty = 25, CreateDate = new DateTime(2010, 1, 13) });
            data.Add(new ProductModel { CategoryName = "HTC", ProductId = 8, ProductName = "One", Price = 7000, Qty = 35, CreateDate = new DateTime(2011, 3, 12) });
            data.Add(new ProductModel { CategoryName = "HTC", ProductId = 9, ProductName = "New One", Price = 15000, Qty = 45, CreateDate = new DateTime(2012, 11, 1), OnSaled = true });
            data.Add(new ProductModel { CategoryName = "HTC", ProductId = 10, ProductName = "Flyer", Price = 3000, Qty = 55, CreateDate = new DateTime(2013, 1, 1), OnSaled = true });

            data.Add(new ProductModel { CategoryName = "Nokia", ProductId = 11, ProductName = "Lumia610", Price = 5000, Qty = 5, CreateDate = new DateTime(2009, 1, 1) });
            data.Add(new ProductModel { CategoryName = "Nokia", ProductId = 12, ProductName = "Lumia710", Price = 7000, Qty = 45, CreateDate = new DateTime(2010, 12, 1) });
            data.Add(new ProductModel { CategoryName = "Nokia", ProductId = 13, ProductName = "Lumia810", Price = 8000, Qty = 35, CreateDate = new DateTime(2011, 11, 30) });
            data.Add(new ProductModel { CategoryName = "Nokia", ProductId = 14, ProductName = "Lumia920", Price = 13000, Qty = 25, CreateDate = new DateTime(2012, 10, 12) });
            data.Add(new ProductModel { CategoryName = "Nokia", ProductId = 15, ProductName = "Lumia1500", Price = 18000, Qty = 5, CreateDate = new DateTime(2013, 9, 12), OnSaled = true });

            return data.AsQueryable();
        }
    }



    //http://msdn.microsoft.com/zh-tw/library/bb882637.aspx
    //class ThirdProgram
    //{
    //    static void Main(string[] args)
    //    {
    //        string[] companies = { "Consolidated Messenger", "Alpine Ski House", "Southridge Video", "City Power & Light",
    //                           "Coho Winery", "Wide World Importers", "Graphic Design Institute", "Adventure Works",
    //                           "Humongous Insurance", "Woodgrove Bank", "Margie's Travel", "Northwind Traders",
    //                           "Blue Yonder Airlines", "Trey Research", "The Phone Company",
    //                           "Wingtip Toys", "Lucerne Publishing", "Fourth Coffee" };
    //        IQueryable<string> queryableData = companies.AsQueryable();
    //        ParameterExpression pe = Expression.Parameter(typeof(string), "company");
    //        // ***** Where(company => (company.ToLower() == "coho winery" || company.Length > 16)) *****
    //        // Create an expression tree that represents the expression 'company.ToLower() == "coho winery"'.
    //        Expression left = Expression.Call(pe, typeof(string).GetMethod("ToLower", System.Type.EmptyTypes));
    //        Expression right = Expression.Constant("coho winery");
    //        Expression e1 = Expression.Equal(left, right);

    //        left = Expression.Property(pe, typeof(string).GetProperty("Length"));
    //        right = Expression.Constant(16);
    //        Expression e2 = Expression.GreaterThan(left, right);

    //        // Combine the expression trees to create an expression tree that represents the
    //        // expression '(company.ToLower() == "coho winery" || company.Length > 16)'.
    //        Expression precidateBody = Expression.OrElse(e1, e2);

    //        // Create an expression tree that represents the expression
    //        // 'queryableData.Where(company => (company.ToLower() == "coho winery" || company.Length > 16))'
    //        MethodCallExpression whereCallExpression = Expression.Call(typeof(Queryable), "Where", new Type[] { queryableData.ElementType }
    //            , queryableData.Expression
    //            , Expression.Lambda<Func<string, bool>>(precidateBody, new ParameterExpression[] { pe }));
    //        //End Where

    //        // ***** OrderBy(company => company) *****
    //        // Create an expression tree that represents the expression
    //        // 'whereCallExpression.OrderBy(company => company)'
    //        MethodCallExpression orderByCallExpression = Expression.Call(typeof(Queryable), "OrderBy", new Type[] { queryableData.ElementType, queryableData.ElementType }
    //            , whereCallExpression
    //            , Expression.Lambda<Func<string, string>>(pe, new ParameterExpression[] { pe }));
    //        // ***** End OrderBy *****
    //        // Create an executable query from the expression tree.
    //        IQueryable<string> results = queryableData.Provider.CreateQuery<string>(orderByCallExpression);

    //        foreach (string company in results)
    //            Console.WriteLine(company);
    //        Console.Read();
    //    }
    //}
    #endregion

}
