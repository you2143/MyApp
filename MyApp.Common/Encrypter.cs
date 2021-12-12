using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Common
{
    public class Encrypter
    {
        // 初期化ベクトル            ----- (4)
        const string AesIV = @"1234567890123456";
        // 暗号化鍵
        const string AesKey = @"12345678901234561234567890123456";

        /// <summary>
        /// 文字列をAESで暗号化
        /// </summary>
        /// <param name="text">暗号化したい文字列</param>
        /// <returns>Base64形式で暗号化された文字列</returns>
        public byte[] Encrypt(string text)
        {

            // 暗号化方式はAES           ----- (1)
            AesManaged aes = new AesManaged();
            // 鍵の長さ                  ----- (2)
            aes.KeySize = 256;
            // ブロックサイズ（何文字単位で処理するか）
            aes.BlockSize = 128;
            // 暗号利用モード             ----- (3)
            aes.Mode = CipherMode.CBC;
            aes.IV = Encoding.UTF8.GetBytes(AesIV);
            aes.Key = Encoding.UTF8.GetBytes(AesKey);
            // パディング                 ----- (5)
            aes.Padding = PaddingMode.PKCS7;

            // 暗号化するためにはバイトの配列に変換する必要がある
            var byteText = Encoding.UTF8.GetBytes(text);

            // 暗号化
            return aes.CreateEncryptor().TransformFinalBlock(byteText, 0, byteText.Length);

            //// Base64形式（64種類の英数字で表現）で返す
            //return Convert.ToBase64String(encryptText);
        }

        /// <summary>
        /// 文字列に復号
        /// </summary>
        /// <param name="text">暗号化したい文字列</param>
        /// <returns>Base64形式で暗号化された文字列</returns>
        public string Decrypt(byte[] bytes)
        {

            // 暗号化方式はAES           ----- (1)
            AesManaged aes = new AesManaged();
            // 鍵の長さ                  ----- (2)
            aes.KeySize = 256;
            // ブロックサイズ（何文字単位で処理するか）
            aes.BlockSize = 128;
            // 暗号利用モード             ----- (3)
            aes.Mode = CipherMode.CBC;
            aes.IV = Encoding.UTF8.GetBytes(AesIV);
            aes.Key = Encoding.UTF8.GetBytes(AesKey);
            // パディング                 ----- (5)
            aes.Padding = PaddingMode.PKCS7;

            // 復号化
            var aaa = aes.CreateDecryptor().TransformFinalBlock(bytes, 0, bytes.Length);

            return Encoding.UTF8.GetString(aaa);

        }
    }
}
