/************************************************************
    文件: ScriptsInfoRecoder.cs
	作者：JiahaoWu
    邮箱: jiahaodev@163.com
    日期: 2013/10/13 12:01
	功能: 记录脚本信息
*************************************************************/

using System;
using System.IO;

public class ScriptsInfoRecoder : UnityEditor.AssetModificationProcessor {
    private static void OnWillCreateAsset(string path) {
        path = path.Replace(".meta", "");
        if (path.EndsWith(".cs")) {
            string str = File.ReadAllText(path);
            str = str.Replace("#CreateAuthor#", Environment.UserName)
                     .Replace("#CreateTime#", DateTime.Now.ToString("yyyy/MM/dd HH:mm"));

            File.WriteAllText(path, str);
        }
    }
}