# A FPS game for study Unity3D

## 项目目标
使用LowPoly风格实现使命召唤4（COD4）新手训练场关卡
## 项目规划
主体功能
- 拾取枪支
- 步枪/手枪切换
- 场景搭建
- 靶子、人质等射击目标
- 爬梯、滑索功能

GUI功能
- 准星显示
- 弹药显示
- 枪支图标切换
- 流程提示文案显示

## 当前进度
### 2021-10-12
拾取枪支
- 使用Camera和Physics组件发射射线检测，检测到对象标签为Weapon时弹出拾取UI提示。
    - 注意事项：对象需具有Collider组件才可被射线检测