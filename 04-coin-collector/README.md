# 吃金币

小球在平面上移动，吃掉随机散布的旋转金币。机制简单，但一节课里塞了四个互相配合的系统。

**场景入口**：`Assets/chiJinBi1/Scenes/SampleScene.unity`

## 玩法

用 WASD 或方向键控制小球移动，靠近金币即自动吃掉。金币会持续自转并上下浮动。

## 技术点

| 文件 | 作用 |
|---|---|
| `Assets/chiJinBi1/scripst/qiouKongZhi.cs` | 批量生成金币 + 移动 + 距离判定拾取 |
| `Assets/chiJinBi1/scripst/XJGengSui.cs` | 相机偏移跟随 |
| `Assets/chiJinBi1/scripst/XuanZhuan.cs` | 金币自转 + `Mathf.Sin` 上下浮动 |
| `Assets/chiJinBi1/scripst/KongZhi.cs` | 最简移动测试 |

四个系统拆开看：

```csharp
// 1. 批量生成 — 一次生成 N 个，坐标随机
for (int i = 0; i < ShuLiang; i++)
{
    pos.x = Random.Range(-19f, 19f);
    pos.z = Random.Range(-19f, 19f);
    pos.y = 1.1f;
    Instantiate(perfab_jinbi, pos, Quaternion.identity);
}
jinbis = GameObject.FindGameObjectsWithTag("jinbi");  // 2. 一次性缓存，避免每帧查找

// 3. 距离判定拾取
foreach (var item in jinbis)
    if (item != null && Vector3.Distance(item.transform.position, transform.position) < 1f)
        Destroy(item);
```

```csharp
// 4. 相机跟随 — 记录初始偏移，之后每帧保持
void Start()  { offset = transform.position - balltransform.position; }
void Update() { transform.position = balltransform.position + offset; }
```

```csharp
// 5. 程序化动画 — 正弦浮动 + 自转
float newY = startPos.y + Mathf.Sin(Time.time * ShuDu) * FuDu;
transform.position = new Vector3(startPos.x, newY, startPos.z);
transform.Rotate(0, 30 * Time.deltaTime * 2, 0);
```

## 场景构成

- `chiJinBi1/`：单场景主版本，`SampleScene.unity` 内含玩家球、金币预制体、相机
- `chiJinBI2/`：双人版本尝试，含 `shuangRen.unity` 与独立的 `金币.prefab`，尚未完成
- `materil/`：四个自建材质球

## 素材与依赖声明

- 金币模型为基础几何体，材质自建
- 全部脚本为本人编写

## 已知不足

- 没有 UI、没有音效、没有胜负判定，纯机制验证
- 场景只有一块 Plane 和一个球，视觉上不能直接作为展示图
- `chiJinBI2` 双人版本未完成，保留仅为记录尝试过程
