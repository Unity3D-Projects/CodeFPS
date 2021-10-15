# Code:FPS
使用Unity3D引擎实现的一款FPS游戏。

使用LowPoly风格仿制《使命召唤4》新手训练场。
## 项目背景
《使命召唤6》是我的启蒙单机游戏。

在很多年前第一次玩到《使命召唤6》的时候，我就被这种电影版的体验震撼了。

原来游戏并不是只有网游，原来单机游戏也可以这么好玩？原来游戏还可以做成这样？

之后开始了十年单机游戏生涯，有幸玩到了COD4/5/7/8/9/10、荣誉勋章、显卡危机、GTA、鬼泣、NFS、马里奥系列、塞尔达传说等优秀作品。

也因此才走上了软件开发的道路。

我认为一个好游戏并不是由画质决定的，新手引导、关卡搭建、流程节奏、剧情走向、音乐音效等非常多的因素都会影响一个游戏带来的体验感。

这个项目使用LowPoly风格仿制《使命召唤4》新手训练场，回味一下这个经典的关卡。

希望你玩的开心。
## 项目规划
### 项目信息
软件版本
- Unity：2018.4.36f1 Personal
- DOTween：DOTween_1_2_632
- 开发工具：JetBrain Rider 2020.1.1

使用Unity商店资源包
- Low Poly FPS Pack
- Low Poly Dungeons Lite
- Low Poly Weapons VOL.1
- Low Poly Storage Pack
- POLYGON Starter Pack

### 一期需求列表（练习场）
#### 2021-10-15新增需求
**主体功能**
- 增加游戏人物语音

**GUI功能**
- 增加下部聊天文字信息（已完成，耗时4h）

#### 2021-10-14新增需求（做不完了啊！！！）
**主体功能**
- 优化枪支子弹弹道，实现子弹扩散
- 优化枪支射击，实现后坐力

#### 2021-10-11需求
**主体功能**
- 拾取枪支（已完成，耗时2h）
- 步枪/手枪切换（已完成，耗时2h）
- 靶场场景搭建（进行中，耗时6h）
    - 地板、墙壁、天花板（进行中，耗时2h）
    - 武器库（已完成，耗时3h）
    - 训练靶场（已完成，耗时1h）
    - 游戏人物、休息台
    - 灯光烘培
- 靶子、油桶等射击目标（已完成，耗时2h）
- 【训练场流程规划】（已完成，耗时10h）

**GUI功能**
- 枪支图标切换（已完成，耗时1h）
- 拾取武器提示（已完成，耗时1h）
- 准星显示
- 流程提示文案显示（已完成，耗时2h）

### 二期需求列表（实战练习场）
**主体功能**
- 爬梯、滑索功能
- 实战场景搭建
- 实战训练计时功能

## 当前进度
### 2021-10-15
#### 完成功能
1. 优化角色切换枪支代码。
2. 完成【训练场流程规划】阶段8。
3. 完成聊天信息UI展示。
    - 使用协程控制聊天文字的展示和隐藏时间。
    
#### 遇到问题
**问题一**： 通过协程控制聊天文字导致代码有点凌乱，有点类似于埋点操作。

解决方法： 暂无。

疑惑：商业游戏是怎么实现的？

### 2021-10-14
#### 完成功能
1. 完成【训练场流程规划】阶段0-7。
2. 经过叶同学提议优化了AK47的子弹生成点，提高子弹精准度。
    - 原始模型的子弹生成点较高，降低到枪口后在开镜状态下会射不准，优化方式为稍微降低一点并增加Y轴角度。
3. 优化训练靶子大小和距离。
4. 实现子弹射击物品产生弹痕效果。
    - 当子弹的碰撞器触发碰撞的时候，判断碰撞体Tag标签并生成弹痕。

#### 遇到问题
**问题一**： 训练场流程分了许多个阶段，而每个阶段里还可能有子阶段，如果全部功能代码都写在一个类里通过if判断，很容易导致文件变得特别巨大，后期难以维护。

解决方法： 将不同阶段逻辑拆解成独立的Script脚本，创建一个Manager来管理流程的运行。

疑惑：商业游戏是怎么实现的？

### 2021-10-13
#### 完成功能
1. UGUI分辨率自适应
    - 通过使用Canvas Scaler组件，将Scale Mode改为Scale with Screen Size完成自适应功能。
2. 靶场场景搭建
3. 修改资源包中的靶子脚本
    - 由自动击倒起立改为手动执行，以满足教学流程。
4. 制作木板靶子
5. 使用UGUI+DOTween实现流程提示文案显示。
    - 需要为对象添加Canvas Group组件，修改组件的Alpha值。
    - 引入DOTween可以很方便的实现淡入淡出效果（DOFade）。
6. 完成【训练场流程规划】阶段0，实现了拾取AK提示。
    
遇到问题
1. 手误操作导致模型组件丢失，原本打算从Git重新Clone一份下来，发现Clone下来的组建也一样会丢失。
查找到问题是gitignore在提交时忽略了meta文件，导致Clone的预制体无法使用。

### 2021-10-12
#### 完成功能
1. 拾取枪支
    - 使用Camera和Physics组件进行射线检测，检测到对象标签为Weapon时弹出拾取UI提示。
        - 注意事项：对象需具有Collider组件才可被射线检测。
2. 步枪/手枪切换。
    - 通过检测按键Alpha1、Alpha2进行步枪、手枪的GameObject激活与隐藏，完成切换效果。
3. 场景地板、围墙搭建，武器库搭建。
    - 花费太多时间在场景搭建中，可以先使用Cube等物体作为临时场景搭建。
