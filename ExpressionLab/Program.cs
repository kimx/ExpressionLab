using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
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
    //class DynamicQueryProgram
    //{
    //    static void Main(string[] args)
    //    {
    //        //DynamicQuery();
    //        DynamicColumn();
    //        Console.Read();
    //    }
    //    private static void DynamicQuery()
    //    {
    //        string sortColumn = "ProductName";
    //        string filterColumn = "CategoryName";
    //        string filterValue = "HTC";
    //        IQueryable<ProductModel> data = ProductModel.GetDatas();
    //        data = OrderBy(data, sortColumn);
    //        data = Where(data, filterColumn, filterValue);
    //        foreach (var item in data)
    //        {
    //            Console.WriteLine(item.ProductName);
    //        }
    //    }

    //    private static void DynamicColumn()
    //    {
    //        IQueryable<ProductModel> data = ProductModel.GetDatas();
    //        var dynamicResult = SelectDynamicColumns(data, "ProductName", "CategoryName");
    //        foreach (var item in dynamicResult)
    //        {
    //            Console.WriteLine(item.ProductName + "-" + item.CategoryName);
    //        }
    //    }

    //    private static void TraditionQuery()
    //    {
    //        string sortColumn = "ProductName";
    //        string filterColumn = "CategoryName";
    //        string filterValue = "HTC";
    //        IQueryable<ProductModel> data = ProductModel.GetDatas();
    //        switch (sortColumn)
    //        {
    //            case "CategoryName":
    //                data = data.OrderBy(m => m.CategoryName);
    //                break;
    //            case "ProductName":
    //                data = data.OrderBy(m => m.ProductName);
    //                break;
    //        }

    //        switch (filterColumn)
    //        {
    //            case "CategoryName":
    //                data = data.Where(m => m.CategoryName == filterValue);
    //                break;
    //            case "ProductName":
    //                data = data.Where(m => m.ProductName == filterValue);
    //                break;
    //        }

    //    }


    //    private static IQueryable<ProductModel> OrderBy(IQueryable<ProductModel> source, string sortColumn)
    //    {
    //        //傳入參數 如:m
    //        ParameterExpression pe = Expression.Parameter(source.ElementType, "m");
    //        //回傳欄位 如:m.ProductName
    //        Expression sortExp = Expression.Property(pe, typeof(ProductModel).GetProperty(sortColumn));
    //        //Lamba運算式 如:m=>m.ProductName
    //        Expression body = Expression.Lambda<Func<ProductModel, string>>(sortExp, new ParameterExpression[] { pe });
    //        //呼叫OrderBy方法
    //        MethodCallExpression OrderByCallExpression = Expression.Call(
    //                        typeof(Queryable),//來源型別
    //                        "OrderBy",//指定方法名稱
    //                        new Type[] { typeof(ProductModel), typeof(string) },//body lamba使用到Expression型別，例:sortExp及pe
    //                        source.Expression,//來源運算式
    //                        body);
    //        var result = (IQueryable<ProductModel>)source.Provider.CreateQuery(OrderByCallExpression);
    //        return result;
    //    }

    //    private static IQueryable<ProductModel> Where(IQueryable<ProductModel> source, string filterColumn, string filterValue)
    //    {
    //        //傳入參數 如:m
    //        ParameterExpression pe = Expression.Parameter(source.ElementType, "m");
    //        //回傳欄位 如:m.CategoryName
    //        Expression filterExp = Expression.Property(pe, typeof(ProductModel).GetProperty(filterColumn));
    //        //條件值 如:"HTC"
    //        ConstantExpression valueExp = Expression.Constant(filterValue, typeof(string));
    //        //等於條件主體 如:m.CategoryName=="HTC"
    //        Expression predicateBody = Expression.Equal(filterExp, valueExp);
    //        //Lamba運算式 
    //        Expression body = Expression.Lambda<Func<ProductModel, bool>>(predicateBody, new ParameterExpression[] { pe });
    //        //呼叫Where方法
    //        MethodCallExpression whereCallExpression = Expression.Call(
    //                        typeof(Queryable),//來源型別
    //                        "Where",//指定方法名稱
    //                        new Type[] { typeof(ProductModel) },//body lamba使用到Expression型別，例:pe
    //                        source.Expression,//來源運算式
    //                        body);
    //        var result = (IQueryable<ProductModel>)source.Provider.CreateQuery(whereCallExpression);
    //        return result;
    //    }

    //    //http://stackoverflow.com/questions/12701737/expression-to-create-an-instance-with-object-initializer
    //    private static IQueryable<ProductTargetModel> SelectDynamicColumns(IQueryable<ProductModel> source, params string[] columns)
    //    {
    //        //傳入參數 如:m
    //        ParameterExpression parSource = Expression.Parameter(source.ElementType, "m");
    //        Type targetType = typeof(ProductTargetModel);
    //        //目標型別的建構式
    //        var ctor = Expression.New(targetType);
    //        List<MemberAssignment> assignment = new List<MemberAssignment>();
    //        foreach (var column in columns)
    //        {
    //            //來源屬性
    //            var sourceValueProperty = source.ElementType.GetProperty(column);
    //            //目標屬性
    //            var targetValueProperty = targetType.GetProperty(column);
    //            //建立參數與欄位節點 如:m.CategoryName
    //            Expression columnExp = Expression.Property(parSource, sourceValueProperty);
    //            //建立成員指定節點 如:CategoryName=m.CategoryName
    //            var displayValueAssignment = Expression.Bind(targetValueProperty, columnExp);
    //            assignment.Add(displayValueAssignment);
    //        }
    //        //將目標型別的成員初始化 例:new ProductTargetModel(){CategoryName=m.CategoryName,...}
    //        var memberInit = Expression.MemberInit(ctor, assignment.ToArray());

    //        //建立Lamba運算式 例: m => new ProductTargetModel(){CategoryName=m.CategoryName,...}
    //        Expression body = Expression.Lambda<Func<ProductModel, ProductTargetModel>>(memberInit, new ParameterExpression[] { parSource });
    //        //呼叫Select方法
    //        MethodCallExpression whereCallExpression = Expression.Call(
    //                        typeof(Queryable),//來源型別
    //                        "Select",//指定方法名稱
    //                        new Type[] { typeof(ProductModel), typeof(ProductTargetModel) },//body lamba使用到Expression型別，例:pe及回傳型別
    //                        source.Expression,//來源運算式
    //                        body);
    //        var result = (IQueryable<ProductTargetModel>)source.Provider.CreateQuery(whereCallExpression);
    //        return result;
    //    }


    //}

    //public class ProductModel
    //{
    //    public int ProductId { get; set; }

    //    public string CategoryName { get; set; }

    //    public string ProductName { get; set; }

    //    public int Qty { get; set; }

    //    public double Price { get; set; }

    //    public DateTime CreateDate { get; set; }

    //    public bool OnSaled { get; set; }

    //    public static IQueryable<ProductModel> GetDatas()
    //    {

    //        List<ProductModel> data = new List<ProductModel>();
    //        data.Add(new ProductModel { CategoryName = "Apple", ProductId = 1, ProductName = "iPhone3", Price = 5000, Qty = 5, CreateDate = new DateTime(2009, 1, 1) });
    //        data.Add(new ProductModel { CategoryName = "Apple", ProductId = 2, ProductName = "iPhone4", Price = 10000, Qty = 6, CreateDate = new DateTime(2010, 3, 1) });
    //        data.Add(new ProductModel { CategoryName = "Apple", ProductId = 3, ProductName = "iPhone4s", Price = 15000, Qty = 15, CreateDate = new DateTime(2011, 4, 1) });
    //        data.Add(new ProductModel { CategoryName = "Apple", ProductId = 4, ProductName = "iPhone5", Price = 20000, Qty = 25, CreateDate = new DateTime(2012, 5, 1), OnSaled = true });
    //        data.Add(new ProductModel { CategoryName = "Apple", ProductId = 5, ProductName = "iPhone5s", Price = 25000, Qty = 5, CreateDate = new DateTime(2013, 6, 8), OnSaled = true });

    //        data.Add(new ProductModel { CategoryName = "HTC", ProductId = 6, ProductName = "Diamond", Price = 5000, Qty = 5, CreateDate = new DateTime(2009, 1, 1) });
    //        data.Add(new ProductModel { CategoryName = "HTC", ProductId = 7, ProductName = "Titan", Price = 6000, Qty = 25, CreateDate = new DateTime(2010, 1, 13) });
    //        data.Add(new ProductModel { CategoryName = "HTC", ProductId = 8, ProductName = "One", Price = 7000, Qty = 35, CreateDate = new DateTime(2011, 3, 12) });
    //        data.Add(new ProductModel { CategoryName = "HTC", ProductId = 9, ProductName = "New One", Price = 15000, Qty = 45, CreateDate = new DateTime(2012, 11, 1), OnSaled = true });
    //        data.Add(new ProductModel { CategoryName = "HTC", ProductId = 10, ProductName = "Flyer", Price = 3000, Qty = 55, CreateDate = new DateTime(2013, 1, 1), OnSaled = true });

    //        data.Add(new ProductModel { CategoryName = "Nokia", ProductId = 11, ProductName = "Lumia610", Price = 5000, Qty = 5, CreateDate = new DateTime(2009, 1, 1) });
    //        data.Add(new ProductModel { CategoryName = "Nokia", ProductId = 12, ProductName = "Lumia710", Price = 7000, Qty = 45, CreateDate = new DateTime(2010, 12, 1) });
    //        data.Add(new ProductModel { CategoryName = "Nokia", ProductId = 13, ProductName = "Lumia810", Price = 8000, Qty = 35, CreateDate = new DateTime(2011, 11, 30) });
    //        data.Add(new ProductModel { CategoryName = "Nokia", ProductId = 14, ProductName = "Lumia920", Price = 13000, Qty = 25, CreateDate = new DateTime(2012, 10, 12) });
    //        data.Add(new ProductModel { CategoryName = "Nokia", ProductId = 15, ProductName = "Lumia1500", Price = 18000, Qty = 5, CreateDate = new DateTime(2013, 9, 12), OnSaled = true });

    //        return data.AsQueryable();
    //    }
    //}

    //public class ProductTargetModel
    //{
    //    public int ProductId { get; set; }

    //    public string CategoryName { get; set; }

    //    public string ProductName { get; set; }

    //    public int Qty { get; set; }

    //    public double Price { get; set; }

    //    public DateTime CreateDate { get; set; }

    //    public bool OnSaled { get; set; }

    //}

    #endregion

    #region DynamicQueryProxy
    /*
     Reference
     * http://www.cnblogs.com/why520crazy/articles/2781596.html
     * http://geekswithblogs.net/abhijeetp/archive/2010/04/04/a-simple-dynamic-proxy.aspx
     * http://www.codeproject.com/Articles/19513/Dynamic-But-Fast-The-Tale-of-Three-Monkeys-A-Wolf
     */
    class DynamicQueryByProxyProgram
    {
        static void Main(string[] args)
        {
            DbContextMock db = new DbContextMock();
            IQueryable<ProductInfo> result = from p in db.Product
                                             join c in db.Category
                                                 on p.CategoryId equals c.CategoryId
                                             select new ProductInfo
                                             {
                                                 CategoryName = c.CategoryName,
                                                 CreateDate = p.CreateDate,
                                                 OnSaled = p.OnSaled,
                                                 Price = p.Price,
                                                 ProductId = p.ProductId,
                                                 ProductName = p.ProductName,
                                                 Qty = p.Qty,

                                             };

            result = result.SelectDynamicProxy("CategoryName", "ProductName");
            foreach (var item in result)
            {
                ProductInfo p = (ProductInfo)item;
                Console.WriteLine("CategoryName:" + item.CategoryName);
                Console.WriteLine("ProductName:" + item.ProductName);
            }

            Console.Read();
        }

    }

    public static class DynamicQueryExtension
    {

        /// <summary>
        /// Select動態欄位回傳代理類別
        /// </summary>
        /// <typeparam name="SourceTarget"></typeparam>
        /// <param name="source"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static IQueryable<SourceTarget> SelectDynamicProxy<SourceTarget>(this IQueryable<SourceTarget> source, params string[] columns)
        {
            //建立代理類別
            var proxy = DynamicProxyGenerator.CreateDynamicProxy<SourceTarget>();
            //傳入參數 如:m
            ParameterExpression parSource = Expression.Parameter(source.ElementType, "m");
            Type targetType = proxy.GetType();
            //目標型別的建構式
            var ctor = Expression.New(targetType);
            List<MemberAssignment> assignment = new List<MemberAssignment>();
            foreach (var column in columns)
            {  //來源屬性
                var sourceValueProperty = source.ElementType.GetProperty(column);
                //目標屬性
                var targetValueProperty = targetType.GetProperty(column);
                //建立參數與欄位節點 如:m.CategoryName
                Expression columnExp = Expression.Property(parSource, sourceValueProperty);
                //建立成員指定節點 如:CategoryName=m.CategoryName
                var displayValueAssignment = Expression.Bind(targetValueProperty, columnExp);
                assignment.Add(displayValueAssignment);
            }
            //將目標型別的成員初始化 例:new ProductTargetModel(){CategoryName=m.CategoryName,...}
            var memberInit = Expression.MemberInit(ctor, assignment.ToArray());
            //建立Lamba運算式 例: m => new ProductTargetModel(){CategoryName=m.CategoryName,...}
            Expression body = Expression.Lambda<Func<SourceTarget, SourceTarget>>(memberInit, new ParameterExpression[] { parSource });
            //呼叫Select方法
            MethodCallExpression whereCallExpression = Expression.Call(
                            typeof(Queryable),//來源型別
                            "Select",//指定方法名稱
                            new Type[] { source.ElementType, source.ElementType },//body lamba使用到Expression型別，例:pe及回傳型別
                            source.Expression,//來源運算式
                            body);
            var result = (IQueryable<SourceTarget>)source.Provider.CreateQuery(whereCallExpression);
            return result;
        }

    }
    internal class DynamicProxyGenerator
    {
        /// <summary>
        ///動態建立代理類別
        ///此方法只建立一個繼承T的代理類別，不作任何欄位、屬性、方法的修改及擴充
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CreateDynamicProxy<T>()
        {
            Type typeNeedProxy = typeof(T);
            //定義動態組件
            AssemblyName assembly = new AssemblyName("DynamicAssembly");
            AssemblyBuilderAccess assemblyBuilderAccess = AssemblyBuilderAccess.Run;
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assembly, assemblyBuilderAccess);
            //定義動態模組
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicAssemblyModule");

            //定義代理類別建立者
            string proxyClassName = string.Format("{0}Proxy", typeNeedProxy.Name);
            TypeBuilder typeBuilderProxy = moduleBuilder.DefineType(proxyClassName, TypeAttributes.Public, typeNeedProxy);
            //定義建構式-開始,此段不加也可以,此段給另外在建構式加入其他邏輯用
            ConstructorBuilder constructorBuilder = typeBuilderProxy.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new Type[] { });
            ILGenerator ilgCtor = constructorBuilder.GetILGenerator();
            ilgCtor.Emit(OpCodes.Ret);//返回
            //定義建構式-結束

            //使用代理類別建立者建立代理類別的型別
            Type proxyClassType = typeBuilderProxy.CreateType();
            //建立代理類別
            var instance = Activator.CreateInstance(proxyClassType);
            return (T)instance;
        }


    }


    public class DbContextMock
    {
        public IQueryable<ProductEntity> Product { get; set; }
        public IQueryable<CategoryEntity> Category { get; set; }

        public DbContextMock()
        {
            List<ProductEntity> productList = new List<ProductEntity>();
            productList.Add(new ProductEntity { CategoryId = 1, ProductId = 1, ProductName = "iPhone3", Price = 5000, Qty = 5, CreateDate = new DateTime(2009, 1, 1) });
            productList.Add(new ProductEntity { CategoryId = 1, ProductId = 2, ProductName = "iPhone4", Price = 10000, Qty = 6, CreateDate = new DateTime(2010, 3, 1) });
            productList.Add(new ProductEntity { CategoryId = 1, ProductId = 3, ProductName = "iPhone4s", Price = 15000, Qty = 15, CreateDate = new DateTime(2011, 4, 1) });
            productList.Add(new ProductEntity { CategoryId = 1, ProductId = 4, ProductName = "iPhone5", Price = 20000, Qty = 25, CreateDate = new DateTime(2012, 5, 1), OnSaled = true });
            productList.Add(new ProductEntity { CategoryId = 1, ProductId = 5, ProductName = "iPhone5s", Price = 25000, Qty = 5, CreateDate = new DateTime(2013, 6, 8), OnSaled = true });

            productList.Add(new ProductEntity { CategoryId = 2, ProductId = 6, ProductName = "Diamond", Price = 5000, Qty = 5, CreateDate = new DateTime(2009, 1, 1) });
            productList.Add(new ProductEntity { CategoryId = 2, ProductId = 7, ProductName = "Titan", Price = 6000, Qty = 25, CreateDate = new DateTime(2010, 1, 13) });
            productList.Add(new ProductEntity { CategoryId = 2, ProductId = 8, ProductName = "One", Price = 7000, Qty = 35, CreateDate = new DateTime(2011, 3, 12) });
            productList.Add(new ProductEntity { CategoryId = 2, ProductId = 9, ProductName = "New One", Price = 15000, Qty = 45, CreateDate = new DateTime(2012, 11, 1), OnSaled = true });
            productList.Add(new ProductEntity { CategoryId = 2, ProductId = 10, ProductName = "Flyer", Price = 3000, Qty = 55, CreateDate = new DateTime(2013, 1, 1), OnSaled = true });

            productList.Add(new ProductEntity { CategoryId = 3, ProductId = 11, ProductName = "Lumia610", Price = 5000, Qty = 5, CreateDate = new DateTime(2009, 1, 1) });
            productList.Add(new ProductEntity { CategoryId = 3, ProductId = 12, ProductName = "Lumia710", Price = 7000, Qty = 45, CreateDate = new DateTime(2010, 12, 1) });
            productList.Add(new ProductEntity { CategoryId = 3, ProductId = 13, ProductName = "Lumia810", Price = 8000, Qty = 35, CreateDate = new DateTime(2011, 11, 30) });
            productList.Add(new ProductEntity { CategoryId = 3, ProductId = 14, ProductName = "Lumia920", Price = 13000, Qty = 25, CreateDate = new DateTime(2012, 10, 12) });
            productList.Add(new ProductEntity { CategoryId = 3, ProductId = 15, ProductName = "Lumia1500", Price = 18000, Qty = 5, CreateDate = new DateTime(2013, 9, 12), OnSaled = true });
            Product = productList.AsQueryable();

            List<CategoryEntity> categoryList = new List<CategoryEntity>();
            categoryList.Add(new CategoryEntity { CategoryId = 1, CategoryName = "Apple" });
            categoryList.Add(new CategoryEntity { CategoryId = 2, CategoryName = "HTC" });
            categoryList.Add(new CategoryEntity { CategoryId = 3, CategoryName = "Nokia" });
            Category = categoryList.AsQueryable();
        }
    }

    public class CategoryEntity
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }


    }

    public class ProductEntity
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string ProductName { get; set; }

        public int Qty { get; set; }

        public double Price { get; set; }

        public DateTime CreateDate { get; set; }

        public bool OnSaled { get; set; }

        public static IQueryable<ProductEntity> GetDatas()
        {

            List<ProductEntity> data = new List<ProductEntity>();
            data.Add(new ProductEntity { CategoryId = 1, ProductId = 1, ProductName = "iPhone3", Price = 5000, Qty = 5, CreateDate = new DateTime(2009, 1, 1) });
            data.Add(new ProductEntity { CategoryId = 1, ProductId = 2, ProductName = "iPhone4", Price = 10000, Qty = 6, CreateDate = new DateTime(2010, 3, 1) });
            data.Add(new ProductEntity { CategoryId = 1, ProductId = 3, ProductName = "iPhone4s", Price = 15000, Qty = 15, CreateDate = new DateTime(2011, 4, 1) });
            data.Add(new ProductEntity { CategoryId = 1, ProductId = 4, ProductName = "iPhone5", Price = 20000, Qty = 25, CreateDate = new DateTime(2012, 5, 1), OnSaled = true });
            data.Add(new ProductEntity { CategoryId = 1, ProductId = 5, ProductName = "iPhone5s", Price = 25000, Qty = 5, CreateDate = new DateTime(2013, 6, 8), OnSaled = true });

            data.Add(new ProductEntity { CategoryId = 2, ProductId = 6, ProductName = "Diamond", Price = 5000, Qty = 5, CreateDate = new DateTime(2009, 1, 1) });
            data.Add(new ProductEntity { CategoryId = 2, ProductId = 7, ProductName = "Titan", Price = 6000, Qty = 25, CreateDate = new DateTime(2010, 1, 13) });
            data.Add(new ProductEntity { CategoryId = 2, ProductId = 8, ProductName = "One", Price = 7000, Qty = 35, CreateDate = new DateTime(2011, 3, 12) });
            data.Add(new ProductEntity { CategoryId = 2, ProductId = 9, ProductName = "New One", Price = 15000, Qty = 45, CreateDate = new DateTime(2012, 11, 1), OnSaled = true });
            data.Add(new ProductEntity { CategoryId = 2, ProductId = 10, ProductName = "Flyer", Price = 3000, Qty = 55, CreateDate = new DateTime(2013, 1, 1), OnSaled = true });

            data.Add(new ProductEntity { CategoryId = 3, ProductId = 11, ProductName = "Lumia610", Price = 5000, Qty = 5, CreateDate = new DateTime(2009, 1, 1) });
            data.Add(new ProductEntity { CategoryId = 3, ProductId = 12, ProductName = "Lumia710", Price = 7000, Qty = 45, CreateDate = new DateTime(2010, 12, 1) });
            data.Add(new ProductEntity { CategoryId = 3, ProductId = 13, ProductName = "Lumia810", Price = 8000, Qty = 35, CreateDate = new DateTime(2011, 11, 30) });
            data.Add(new ProductEntity { CategoryId = 3, ProductId = 14, ProductName = "Lumia920", Price = 13000, Qty = 25, CreateDate = new DateTime(2012, 10, 12) });
            data.Add(new ProductEntity { CategoryId = 3, ProductId = 15, ProductName = "Lumia1500", Price = 18000, Qty = 5, CreateDate = new DateTime(2013, 9, 12), OnSaled = true });

            return data.AsQueryable();
        }
    }

    public class ProductInfo
    {
        public int ProductId { get; set; }

        public string CategoryName { get; set; }

        public string ProductName { get; set; }

        public int Qty { get; set; }

        public double Price { get; set; }

        public DateTime CreateDate { get; set; }

        public bool OnSaled { get; set; }

    }

    #endregion



}
