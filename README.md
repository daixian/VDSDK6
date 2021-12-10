# SDK6
zspace6.0的SDK,本项目使用Unity2019.4.32f1构建。

# 从零构建工程
## 下载zspace6.0的SDK
在[zsapce sdk官网页面](https://developer.zspace.com/downloads)下载[zCore Unity Plugin 6.0.2](https://cdn.zspace.com/downloads/developer-resources/zCore-6.0.2.unitypackage)和[zView Unity Plugin 6.0.0](https://cdn.zspace.com/downloads/developer-resources/zView-6.0.0.unitypackage)这两个unity资源包.
![](https://user-images.githubusercontent.com/15939998/145576244-dc03240d-0d6c-4e31-b486-590e82ef3a96.png)


## 构建U3D工程
打开u3d创建一个空工程，依次导入上面的两个u3d资源包，这里有以下几点需要注意。

* 只支持Unity2020以下版本。
* 为了实现立体3D效果，所以项目必须使用DX11渲染API发布。
* 由于引擎内部的原因，需要选择普通的3D项目，不支持URP项目（发布出来右眼相机未渲染）。

导入资源包之后在项目发布设置Player Settings最下面的XR Setting中添加StereoDisplay(non head-mounted)。
步骤:
* 勾选支持VR 
    <div align=center><img src="https://user-images.githubusercontent.com/15939998/145576258-13bc0240-dc00-4e5b-9e0a-68ac0a330721.png" width="400"></div>

* 添加一项
    <div align=center><img src="https://user-images.githubusercontent.com/15939998/145576266-e0d55822-181e-419b-a915-8f44bf20f77e.png" width="400"></div>

* 添加需要的项,删除不需要的项最后如图
  <div align=center><img src="https://user-images.githubusercontent.com/15939998/145576266-e0d55822-181e-419b-a915-8f44bf20f77e.png" width="400"></div>

此时已经完成了一个初始zSpace空项目的创建.

## 替换原生dll
下载本项目中Extra文件夹里zCoreUnity.dll和zViewUnity.dll。关闭U3D项目，进行文件的替换覆盖，注意32位和64位的区别。文件位置如下图：
<div align=center><img src="https://user-images.githubusercontent.com/15939998/145577352-fc275711-e82d-4376-b23c-effcf19fd4c1.png" width="40%"></div>