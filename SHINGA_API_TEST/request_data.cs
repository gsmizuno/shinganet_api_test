using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

[DataContract]
public class request_data
{
    //品目名
    [DataMember(Name = "class_room_id", Order = 0)]
    public int? class_room_id;

    //品目コード
    [DataMember(Name = "id", Order = 1)]
    public IList<int> id;

    //詳細
    [DataMember(Name = "sei", Order = 2)]
    public string sei;

    //単価
    [DataMember(Name = "mei", Order = 3)]
    public string mei;

    //単位
    [DataMember(Name = "sei_kana", Order = 4)]
    public string sei_kana;

    //数量
    [DataMember(Name = "mei_kana", Order = 5)]
    public string mei_kana;

    //品目名
    [DataMember(Name = "limit", Order = 6)]
    public int limit;

    //品目名
    [DataMember(Name = "offset", Order = 7)]
    public int offset;
}