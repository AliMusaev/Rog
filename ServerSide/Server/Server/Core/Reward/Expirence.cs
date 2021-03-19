using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Reward
{
    class Expirence
    {
        // Must be loaded from config file
        private const int newFp = 25;

        private RogDBEntities context;

        public Expirence(RogDBEntities context)
        {
            this.context = context;
        }

        public byte CalculateExpData(int userId, int enemyLvl, int enemyType, int zoneMode)
        {
            var newExp = CalculateAddedExp(enemyLvl, enemyType, zoneMode);

            var calculationResult = CalculateLvlsUp(LoadDataFromDb(userId), newExp);

            return UpdateDataInDb(userId, calculationResult);

        }
        // Calculate how much expirience the user will need to get to the next level
        private int CalculateReqExp(int? input)
        {
            // Testing formula
            return (int)(input + input / 5);
        }
        
        // Calculate how match exp gained by user
        private int CalculateAddedExp(int enemyLvl, int enemyType, int zoneMode)
        {
            // Test formula
            return enemyLvl * enemyType * zoneMode * 25;

        }
        // calculate new values and return new cloned array
        private int?[] CalculateLvlsUp(int?[] values, int exp)
        {
            int?[] retArr = new int?[4];
            values[0] += exp;
            while (values[0] >= values[1])
            {
                values[1] = CalculateReqExp(values[1]);
                values[2]++;
                values[3] += 25;
            }
            retArr = (int?[])values.Clone();
            return retArr;
        }
        // load values from db and return new array
        private int?[] LoadDataFromDb(int userId)
        {
            int?[] retArr = new int?[4];


            retArr[1] = context.GeneralStats.Find(userId).Exp;
            retArr[2] = context.GeneralStats.Find(userId).ReqExp;
            retArr[3] = context.GeneralStats.Find(userId).Lvl;
            retArr[4] = context.GeneralStats.Find(userId).Fp;
            return retArr;
        }
        private byte UpdateDataInDb(int userId, int?[] values)
        {
            var opResult = new ObjectParameter("opResult", typeof(byte));
            context.UpdateUserExp(userId, values[0], values[1], values[2], values[3], opResult);
           return (byte)opResult.Value;
        }
    }
}
