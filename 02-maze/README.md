# 迷宫寻宝

双场景小游戏。从开始页进入迷宫，用物理力推动小球吃满 12 个金币获胜。

**场景入口**：`Assets/Scenes/kaishi.unity`（开始页）→ `Assets/Scenes/miGong.unity`（迷宫）

## 玩法

开始页点击进入迷宫。小球受物理力驱动，在迷宫里收集 12 个旋转金币，吃满弹出胜利面板。撞到墙时墙体变红作为碰撞反馈。

## 技术点

| 文件 | 作用 |
|---|---|
| `Assets/ctrl.cs` | 玩家控制 + 金币拾取 + 计分 + 胜利判定 + 撞墙反馈 |
| `Assets/jingBi.cs` | 金币自身持续旋转 |
| `Assets/tiaozhuan.cs` | 按场景名跳转（开始页 → 迷宫） |
| `Assets/li.cs` | 施加向上/向前力的测试脚本 |

关键实现：

```csharp
// 物理驱动而非直接改坐标
float h = Input.GetAxis("Horizontal");
float v = Input.GetAxis("Vertical");
rigidbody.AddForce(h, 0, v);

// 碰撞拾取 — 用 Collision 不用 Trigger，保留实体阻挡感
private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.tag == "jingBi")
    {
        Destroy(collision.gameObject);
        i++;
        jiSuQi.text = i.ToString();
        if (i == 12) ShengLi.SetActive(true);
    }
    if (collision.gameObject.tag == "qiang")
        collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
}
```

这个项目是技术路线上的分水岭：**此前用 `transform.Translate` 直接改坐标，这里改用 `Rigidbody.AddForce` 让物理引擎接管**，移动有了惯性和摩擦，手感完全不同。

## 场景构成

- `kaishi.unity`：开始界面，按钮触发场景跳转
- `miGong.unity`：迷宫本体，含玩家刚体、金币预制体、墙体、胜利面板
- `jingBi.prefab`：金币预制体，挂 `jingBi.cs` 做自转

## 素材与依赖声明

- ⚠️ 界面背景图 `OIP-C.PNG`、`OIP-C (1).PNG`、`OIP-C (2).PNG`、`未标题-1.png` 来源不明，原为课程练习素材（文件名带 "OIP-" 前缀，为图片搜索下载的命名格式）。**如需公开传播，建议替换为自制素材**，替换时保持文件名与 `.meta` 不变即可，场景引用不会断。
- 迷宫墙体与金币模型为基础几何体，材质为自建
- 全部脚本为本人编写

## 已知不足

- 金币总数 12 硬编码在 `ctrl.cs` 中，调整关卡需要改代码
- 撞墙变色后不恢复，视觉上会持续留红
- `jiSuQi`（计速器）变量名实际承载的是金币计数，命名有误导
- 没有失败判定与计时
