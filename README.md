# Unity 课程作品集

2026 年 4 月 — 7 月，Unity 课程期间完成的四个项目。

三个月里的技术轨迹很清晰：**5 月还在用 `transform.Translate` 直接改坐标让物体动，6 月开始用 `Rigidbody.AddForce` 和碰撞体系搭关卡，7 月已经会为一个场景设计氛围和目标。**

---

## 技术演进

| 时间 | 阶段 | 关键技术 | 产出 |
|---|---|---|---|
| 4 月 | 环境与资产 | 材质球、贴图导入、Terrain 地形雕刻、3ds Max → Unity 模型管线 | 地形场景（4 个版本迭代）、木桌模型 |
| 5 月上 | 单点验证 | `Transform` 位移旋转、键盘鼠标输入、`Instantiate` / `Destroy`、预制体 | 移动控制脚本、宝箱生成器 |
| 5 月下 | 第一个玩法闭环 | 批量随机生成、`Vector3.Distance` 判定、相机跟随、`Mathf.Sin` 程序化动画 | **吃金币** |
| 6 月上 | 多媒体控制 | `AudioSource` 生命周期、Skybox 动态替换、双相机 | 天空盒切换器、音频控制器 |
| 6 月下 | 应用与关卡 | UGUI 表单校验、`SceneManager` 多场景流转、物理驱动、碰撞/触发两套检测 | **星空探索**、**迷宫寻宝** |
| 7 月 | 氛围与叙事 | 第一人称探索、目标计数、音效反馈、完成面板 | **病树** |

> 表中 4 月与 5 月上的产出属于课程前期的上手练习（材质、地形、单点 API 验证），没有独立的成品形态，**未收录进本仓库**。本仓库收录的是 5 月下之后四个有完整玩法或流程的项目。

---

## 项目

### 01 · 病树 `01-bingshu/`

第一人称走进一片树林，靠近标了 `sick` 标签的病树即可清除，累计 6 棵后弹出完成面板。有病毒消失音效、实时计数 UI、10 套天空盒可切换氛围。

**技术点**
- `OnTriggerEnter` 触发器检测，按 `tag == "sick"` 分流
- 反馈链同帧完成：销毁对象 → `AudioSource.Play()` → `Text.text` 刷新
- `count == 6` 驱动 `panel.SetActive(true)`，构成"做任务 → 有终点"的闭环
- 场景资产完整：Terrain 地形 + 两套树木模型（含枯树变体）+ 预制体 + 背景音乐

**展示价值**：这批项目里唯一有"氛围设计"的，不是 API 演示而是能讲故事的体验。

---

### 02 · 迷宫寻宝 `02-maze/`

双场景小游戏。`kaishi.unity` 是开始页，`miGong.unity` 是迷宫本体。用物理力推动小球吃 12 个金币，吃满弹出胜利面板，撞墙则墙变红。

**技术点**
- `rigidbody.AddForce(h, 0, v)` 物理驱动移动，与早期的 `transform.Translate` 是两条不同路线
- 拾取用 `OnCollisionEnter`（需要真实阻挡感），而非 Trigger
- 计数 `i++` → `jiSuQi.text` 实时刷新 → `i == 12` 触发胜利面板
- `SceneManager.LoadScene(sceneName)` 按名跳转，开始页与游戏页串通

**展示价值**：最能证明"能独立收尾一个游戏"——有开始、有目标、有胜负、有退出。

---

### 03 · 星空探索 `03-starry-explorer/`

三场景教育展示应用。`denglu` 登录页（账号 `admin` / 密码 `123`）→ `SampleScene` 主界面 → `MuXing` 木星详情页。含错误提示、重置、退出三个交互分支。

**技术点**
- `InputField.text` 表单校验 + 失败时 `cuoWuTiShi.SetActive(true)` 错误提示层
- `SceneManager.LoadScene` 三场景串接，含返回上一级
- `SetActive` 控制资料弹层显隐
- 行星图集 + GIF 背景 + 图标分目录管理

**展示价值**：唯一的应用型（非游戏）作品，能证明也能做教育、展示类交互。

---

### 04 · 吃金币 `04-coin-collector/`

小球在平面移动，吃掉随机散布的金币。机制简单，但一节课里塞了四个互相配合的系统。

**技术点**
- `for` + `Random.Range(-19f, 19f)` 批量生成金币
- `GameObject.FindGameObjectsWithTag("jinbi")` 一次性缓存为数组，避免每帧查找
- `Vector3.Distance(...) < 1f` 逐帧遍历判定拾取
- 相机跟随：启动记 `offset = 相机位置 - 目标位置`，之后每帧 `目标 + offset`
- `Mathf.Sin(Time.time * 速度) * 幅度` 上下浮动 + `Rotate` 自转

**展示价值**：单独看不惊艳，但它是承上启下的关键一环——第一个把"生成 / 判定 / 跟随 / 动画"串成闭环的项目。

---

## 运行方式

需要 **Unity 2022.3.62f1c1**（其他 2022.3.x 版本通常也能打开，会提示升级）。

```
用 Unity Hub 添加对应项目文件夹 → 打开
01-bingshu          场景：Assets/Scene/main.unity
02-maze             场景：Assets/Scenes/kaishi.unity（从这里开始）
03-starry-explorer  场景：Assets/Scenes/denglu.unity（从这里开始）
04-coin-collector   场景：Assets/chiJinBi1/Scenes/SampleScene.unity
```

操作方式：`01` 用鼠标转视角、WASD 移动；`02`/`04` 用 WASD 或方向键驱动；`03` 用鼠标点击 UI。

---

## 关于这个仓库

**代码风格说明**：项目写于学习期间，脚本类名保留了当时的拼音命名（如 `dengLuPD`、`qiouKongZhi`、`ShengChengBaoXiangJiaoBen`），注释为中文。这是真实的学习痕迹，未做美化重写。如果你要读代码，从各项目 README 里标注的入口脚本开始会更快。

**外部资源声明**：
- `01-bingshu` 与 `04-coin-collector` 的第一人称/角色控制器基于 Unity **Standard Assets**，玩法逻辑与场景搭建为原创。
- 树木、天空盒、金币、行星图等模型与贴图来自课程素材包，非本人制作。
- `02-maze` 的两张界面背景图（`OIP-C*.PNG`）来源不明，原为课程练习素材，**如需公开传播建议替换为自制素材**。

**已知不足**：四个项目都是课程练习，体量在单场景到三场景之间，没有存档、设置菜单、难度曲线这类完整商业项目的系统。它们的价值在于展示了从"让物体动"到"让玩法成立"的完整学习路径。

---

## 环境

- Unity 2022.3.62f1c1
- 平台：Windows
- 渲染管线：Built-in
