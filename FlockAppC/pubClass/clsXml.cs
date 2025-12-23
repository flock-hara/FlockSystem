using System;
using System.Xml;

public class ClsXml
{
    private readonly XmlDocument _xmlDoc;
    private readonly string _filePath;

    // コンストラクタ：ファイルパスを受け取り、XMLドキュメントをロード
    public ClsXml(string filePath)
    {
        _filePath = filePath;
        _xmlDoc = new XmlDocument();

        try
        {
            _xmlDoc.Load(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"XMLファイルの読み込み中にエラーが発生しました: {ex.Message}");
        }
    }

    // 特定のノードをXPathで取得
    // public XmlNode? GetNode(string xPath)
    public XmlNode GetNode(string xPath)
    {
        return _xmlDoc.SelectSingleNode(xPath);
    }

    // 新しいノードの追加
    public void AddNode(string parentXPath, string newNodeName, string innerText)
    {
        // XmlNode? parentNode = _xmlDoc.SelectSingleNode(parentXPath);
        XmlNode parentNode = _xmlDoc.SelectSingleNode(parentXPath);
        if (parentNode == null)
        {
            Console.WriteLine("指定された親ノードが見つかりませんでした。");
            return;
        }

        XmlElement newElement = _xmlDoc.CreateElement(newNodeName);
        newElement.InnerText = innerText;
        parentNode.AppendChild(newElement);
    }

    // ノードの内容を更新
    public void UpdateNode(string xPath, string newValue)
    {
        // XmlNode? node = _xmlDoc.SelectSingleNode(xPath);
        XmlNode node = _xmlDoc.SelectSingleNode(xPath);
        if (node != null)
        {
            node.InnerText = newValue;
        }
        else
        {
            Console.WriteLine("指定されたノードが見つかりませんでした。");
        }
    }

    // XMLドキュメントの保存
    public void Save()
    {
        try
        {
            _xmlDoc.Save(_filePath);
            Console.WriteLine("XMLファイルを保存しました。");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"XMLファイルの保存中にエラーが発生しました: {ex.Message}");
        }
    }
    /// <summary>
    /// リスト値取得
    /// DB設定リストに特化した処理（汎用性なし）
    /// </summary>
    /// <param name="xPath"></param>
    /// <param name="p_server"></param>
    /// <param name="p_database"></param>
    /// <param name="p_user"></param>
    /// <param name="p_password"></param>
    public void GetList(string xPath,
                        ref string[] p_dbms,
                        ref string[] p_server,
                        ref string[] p_database,
                        ref string[] p_user,
                        ref string[] p_password)
    {
        XmlNodeList itemList = _xmlDoc.SelectNodes(xPath);

        var i = 0;
        foreach (XmlNode itemNode in itemList)
        {
            p_dbms[i] = itemNode["Dbms"].InnerText ?? "";
            p_server[i] = itemNode["Server"].InnerText ?? "";
            p_database[i] = itemNode["Database"].InnerText ?? "";
            p_user[i] = itemNode["User"].InnerText ?? "";
            p_password[i] = itemNode["Password"].InnerText ?? "";
            i++;
        }
    }
}
