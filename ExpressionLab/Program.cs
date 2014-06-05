using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Basic();
            //BasicByTree();
            //BasicConstant();
            //BasicLessThan();
            //BasicLabelTarget();
            //BasicBlock();
            //BasicParseLamba();
            BasicExcutePower();
            Console.Read();
        }

        private static void Basic()
        {
            Console.WriteLine("");
            Console.WriteLine("Basic");
            Expression<Func<int, int>> basic = n => n * n;
            Console.WriteLine(basic.Body);
            Console.WriteLine(basic.Parameters[0]);
            Console.WriteLine(basic.NodeType);
            Console.WriteLine(basic.ReturnType);
            Console.WriteLine(basic.Compile()(10));
        }
        private static void BasicByTree()
        {
            Console.WriteLine("");
            Console.WriteLine("BasicByTree");
            ParameterExpression pe = Expression.Parameter(typeof(int), "n");
            Expression<Func<int, int>> expr = Expression<Func<int, int>>.Lambda<Func<int, int>>(Expression.Multiply(pe, pe), new ParameterExpression[] { pe });
            Console.WriteLine(expr.Body);
            Console.WriteLine(expr.Parameters[0]);
            Console.WriteLine(expr.NodeType);
            Console.WriteLine(expr.ReturnType);
            Console.WriteLine(expr.Compile()(10));
        }
        private static void BasicConstant()
        {
            Console.WriteLine("");
            Console.WriteLine("BasicConstant");
            ParameterExpression pe = Expression.Parameter(typeof(int), "n");
            ConstantExpression five = Expression.Constant(5);
            Expression<Func<int, bool>> expr = Expression<Func<int, bool>>.Lambda<Func<int, bool>>(Expression.Equal(pe, five), new ParameterExpression[] { pe });
            Console.WriteLine(expr.Body);
            Console.WriteLine(expr.Parameters[0]);
            Console.WriteLine(expr.NodeType);
            Console.WriteLine(expr.ReturnType);
            Console.WriteLine(expr.Compile()(10));
        }
        private static void BasicLessThan()
        {
            ParameterExpression numParm = Expression.Parameter(typeof(int), "num");
            ConstantExpression five = Expression.Constant(5, typeof(int));
            BinaryExpression numLessThanFive = Expression.LessThan(numParm, five);
            Expression<Func<int, bool>> expr = Expression.Lambda<Func<int, bool>>(numLessThanFive, numParm);
            Console.WriteLine("");
            Console.WriteLine("BasicLessThan");
            Console.WriteLine(expr.Body);
            Console.WriteLine(expr.Parameters[0]);
            Console.WriteLine(expr.NodeType);
            Console.WriteLine(expr.ReturnType);
            Console.WriteLine(expr.Compile()(20));
        }
        private static void BasicLabelTarget()
        {
            LabelTarget returnTarget = Expression.Label();

            // This block contains a GotoExpression that represents a return statement with no value.
            // It transfers execution to a label expression that is initialized with the same LabelTarget as the GotoExpression.
            // The types of the GotoExpression, label expression, and LabelTarget must match.
            BlockExpression blockExpr =
                Expression.Block(
                    Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("GoTo")),
                    Expression.Goto(returnTarget),
                //Other Work不會被執行，因為Goto會跳到下下一行
                    Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("Other Work")),
                    Expression.Label(returnTarget),
                    Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("Label Work"))
                );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Expression.Lambda<Action>(blockExpr).Compile()();
        }
        private static void BasicBlock()
        {
            ParameterExpression value = Expression.Parameter(typeof(int), "value");
            ParameterExpression result = Expression.Parameter(typeof(int), "result");
            LabelTarget label = Expression.Label(typeof(int));
            BlockExpression block = Expression.Block(//建立方法區塊
                new[] { result },//指定方法的參數
                Expression.Assign(result, Expression.Constant(1)),//設定變數result=1
                Expression.Loop(
                     Expression.IfThenElse(
                        Expression.GreaterThan(value, Expression.Constant(1)),
                        Expression.MultiplyAssign(result, Expression.PostDecrementAssign(value)),
                       Expression.Break(label, result)
                ), label
                )
                );
            var lamba = Expression.Lambda<Func<int, int>>(block, value);
            int factorial = lamba.Compile()(5);
            Console.WriteLine(lamba);
            Console.WriteLine(factorial);
        }
        private static void BasicParseLamba()
        {
            Expression<Func<int, bool>> lamba = num => num < 5;
            ParameterExpression param = (ParameterExpression)lamba.Parameters[0];
            BinaryExpression operation = (BinaryExpression)lamba.Body;
            ParameterExpression left = (ParameterExpression)operation.Left;
            ConstantExpression right = (ConstantExpression)operation.Right;
            Console.WriteLine("BasicParseLamba: {0} => {1} {2} {3}",
                  param.Name, left.Name, operation.NodeType, right.Value);
        }

        private static void BasicExcutePower()
        {
            BinaryExpression be = Expression.Power(Expression.Constant(2D), Expression.Constant(3D));
            Expression<Func<double>> lamba = Expression.Lambda<Func<double>>(be);
            double result = lamba.Compile()();
            Console.WriteLine("BasicExcutePower:" + result); ;
        }
    }
}
