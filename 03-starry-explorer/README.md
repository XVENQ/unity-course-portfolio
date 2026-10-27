# 星空探索

三场景教育展示应用。登录 → 主界面 → 木星详情页。

**场景入口**：`Assets/Scenes/denglu.unity`

## 玩法

登录页输入账号 `admin`、密码 `123` 进入主界面；输错则显示错误提示层，可点击重置清空输入或退出程序。主界面点击"开始探索"进入木星详情页，可打开资料弹层，也可返回或退出。

## 技术点

| 文件 | 作用 |
|---|---|
| `Assets/dengLuPD.cs` | 登录校验、错误提示、重置、退出 |
| `Assets/TiaoZhusn.cs` | 开始探索（跳转 `MuXing`）、退出 |
| `Assets/DaKaiZiLiao.cs` | 资料弹层开关、返回主场景 |

关键实现：

```csharp
public void dengLu()
{
    if (yongHuMing.text == "admin" && miMa.text == "123")
        SceneManager.LoadScene("SampleScene");   // 校验通过才放行
    else
        cuoWuTiShi.SetActive(true);              // 失败则亮出提示层
}

public void chongZhi()
{
    yongHuMing.text = "";
    miMa.text = "";
    cuoWuTiShi.SetActive(false);
}
```

这一课的重点不是玩法，而是**界面流程的完整性**：每个界面都有"进去"和"退出来"两条路，弹层有开有关，校验有成功有失败分支。三个场景串成 `denglu → SampleScene → MuXing` 的线性导航。

## 场景构成

- `denglu.unity`：Canvas + 两个 InputField + 登录/重置/退出按钮 + 错误提示层
- `SampleScene.unity`：主界面，标题 + "开始探索" + "退出探索" + 面板
- `MuXing.unity`：木星详情页，图集 + 资料按钮 + 返回/退出
- `星空探索素材/`：9 张行星图（`img1`—`img6`、`木星.png`、`muxing.png`）、`bg1.jpg`、`bg.gif` 动态背景

## 素材与依赖声明

- 行星图片与背景为课程素材包，非本人制作
- UI 布局、脚本逻辑、场景跳转为本人完成
- 使用 TextMeshPro 渲染部分文本

## 已知不足

- 密码 `admin/123` 明文硬编码在脚本里，仅作教学演示，不是真实鉴权
- 木星页只有静态图集，缺少可交互内容
- 没有从木星页返回登录页的完整闭环（只能回到主界面）
- `Assets/` 下三个脚本平铺在根目录，没有按功能分目录
