# 病树

第一人称探索类小项目。走进一片病树林，靠近病树即清除病毒，清满 6 棵后完成。

**场景入口**：`Assets/Scene/main.unity`

## 玩法

第一人称视角在树林中行走，走到标了 `sick` 标签的病树旁自动触发清除，伴随音效与计数。清满 6 棵弹出结束面板。

## 技术点

| 文件 | 作用 |
|---|---|
| `Assets/Scripts/triggerTree.cs` | 核心逻辑：触发器检测 → 销毁 → 音效 → 计数 → 完成判定 |
| `Assets/XiaoMeiBS.cs` | 另一套计数实现（按 8 棵判定），课程迭代时的对照版本 |
| `Assets/tiaozhuan.cs` | 三相机切换 + 退出，用于不同视角观察场景 |

关键实现：

```csharp
private void OnTriggerEnter(Collider other)
{
    if (other.tag == "sick")
    {
        Destroy(other.gameObject);
        ads.Play();               // 病毒消失音效
        count++;
        txt.text = count.ToString();  // UI 实时刷新
        if (count == 6) panel.SetActive(true);  // 完成面板
    }
}
```

设计上选了 **Trigger（穿透检测）而不是 Collision（实体碰撞）** —— 玩家应该能"穿过"病树完成清除，而不是被树挡住。这是这一课最关键的判断。

## 场景构成

- Terrain 地形（含 TerrainLayer 与自动升级产生的 `_TerrainAutoUpgrade`）
- 两套树木模型：`tree.FBX`（健康）/ `树（1）.FBX`（枯树），对应 `tree.prefab` 与 `sickTree.prefab`
- 10 套天空盒材质 `Sky_01` — `Sky_10`，可切换不同氛围
- 音频：`背景音乐.mp3`、`消失.mp3`

## 素材与依赖声明

- 第一人称控制器来自 Unity **Standard Assets**（`Assets/Standard Assets/Characters/FirstPersonCharacter`），未做改造
- 树木模型、天空盒、音频为课程素材包，非本人制作
- 玩法逻辑、场景搭建、UI 与预制体配置为原创

## 已知不足

- 只有胜利条件，没有失败条件，不能重开
- 清除目标数 6 硬编码在脚本里
- 依赖 Standard Assets 的完整资源包，导致仓库体积偏大（约 460 MB），删减会破坏预制体引用
