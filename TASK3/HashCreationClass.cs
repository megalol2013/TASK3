using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace TASK3
{
    
    public class HashCreationClass
    {
        public static byte[] KeyCreation()
        {
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();

            byte[] data = new byte[32];
            rng.GetBytes(data);
            return data;

        }

        public static string HashCreation(byte[] hashKey,string move)
        {
            move = BitConverter.ToString(hashKey).Replace("-", "") + move;
            byte[] hash = Encoding.ASCII.GetBytes(move);
            var hashAlgorithm = new Org.BouncyCastle.Crypto.Digests.Sha3Digest(256);
            hashAlgorithm.BlockUpdate(hash, 0, hash.Length);
            byte[] result = new byte[32];
            hashAlgorithm.DoFinal(result, 0);
            string hashString = BitConverter.ToString(result);
            hashString = hashString.Replace("-", "");
            return hashString;
            
        }
    }
}
