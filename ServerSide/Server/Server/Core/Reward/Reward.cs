using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Reward
{
    class Reward
    {
        private readonly object __lockObj = new object();
        private RogDBEntities context;
        private Expirence expirence;
        private byte retVal;
        private int id;
        bool battleReuslt;
        private int enemyLvl;
        private int enemyType;
        private int zoneMode;
        public Reward(RogDBEntities context)
        {
            this.context = context;
            expirence = new Expirence(context);
        }
        // 0 - userId 1 - battleResult 2 - enemyLvl 3 - enemyLvl 4 - zoneMode
        public byte HandleReward(List<string> inputData, out string outputData)
        {
            PrepareInputData(inputData);
            if (retVal == 0)
            {
                retVal = expirence.CalculateExpData(id, enemyLvl, enemyType, zoneMode);
                if (retVal == 0)
                {

                }
                else
                {
                    outputData = null;
                }
            }
            else
            {
                outputData = null;
            }

            return retVal;
            





        }
        private void PrepareInputData(List<string> reqFields)
        {
            if (int.TryParse(reqFields[0], out id))
            {
                if (bool.TryParse(reqFields[1], out battleReuslt))
                {
                    if (int.TryParse(reqFields[2], out enemyLvl))
                    {
                        if (int.TryParse(reqFields[3], out enemyType))
                        {
                            if (int.TryParse(reqFields[4], out zoneMode))
                            {
                                retVal = 0;
                            }
                            else
                                retVal = 19;
                        }
                        else
                            retVal = 18;
                    }
                    else
                        retVal = 17;
                }
                else
                    retVal = 16;
            }
            else
                retVal = 15;
    }
}
