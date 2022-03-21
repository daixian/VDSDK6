# SDK6
该示例项目基于zspace6.0的SDK,本项目使用Unity2019.4.32f1从零开始构建工程。

# 从零构建工程
## 下载zspace6.0的SDK
在[zsapce sdk官网页面](https://developer.zspace.com/downloads)下载[zCore Unity Plugin 6.0.2](https://cdn.zspace.com/downloads/developer-resources/zCore-6.0.2.unitypackage)和[zView Unity Plugin 6.0.0](https://cdn.zspace.com/downloads/developer-resources/zView-6.0.0.unitypackage)这两个unity资源包.

<div align=center><img src="https://user-images.githubusercontent.com/15939998/145576244-dc03240d-0d6c-4e31-b486-590e82ef3a96.png" width="500"></div>


## 构建U3D工程
打开u3d创建一个空工程，依次导入上面的两个u3d资源包，这里有以下几点需要注意。

* 只支持Unity2020以下版本。
* 为了实现立体3D效果，所以项目必须使用DX11渲染API发布。
* 由于引擎内部的原因，需要选择普通的3D项目，不支持URP项目（发布出来右眼相机未渲染）。

导入资源包之后在项目发布设置Player Settings最下面的XR Setting中添加StereoDisplay(non head-mounted)。
步骤:
* 勾选支持VR 
    <div align=center><img src="https://user-images.githubusercontent.com/15939998/145576258-13bc0240-dc00-4e5b-9e0a-68ac0a330721.png" width="500"></div>

* 添加一项
    <div align=center><img src="https://user-images.githubusercontent.com/15939998/145576266-e0d55822-181e-419b-a915-8f44bf20f77e.png" width="500"></div>

* 添加需要的Stereo Display(non head-mounted)这项，删除不需要的项，最后如图
  <div align=center><img src="https://user-images.githubusercontent.com/15939998/145576275-a064c221-6590-41c9-9726-7409ff498ca7.png" width="500"></div>

此时已经完成了一个初始zSpace空项目的创建.

## 替换原生dll
下载本项目中Extra文件夹里zCoreUnity.dll和zViewUnity.dll。关闭U3D项目，进行文件的替换覆盖，注意32位和64位的区别。文件位置如下图：
<div align=center><img src="https://user-images.githubusercontent.com/15939998/145577352-fc275711-e82d-4376-b23c-effcf19fd4c1.png" width="40%"></div>

## 修改两处屏幕分辨率相关的代码
由于它原来的代码中使用了屏幕分辨率,在4k屏等超高清屏幕下会有问题,所以我们应该把分辨率都统一在1920x1080.
1. ZApplicationWindow.cs的33行开始
``` c#
        public static RectInt Rect
        {
            get
            {
                // dx:统一1920x1080
                return new RectInt(0, 0, 1920, 1080);
//#if UNITY_EDITOR
//                // Grab the position and size of the GameView window
//                // when running from the editor.
//                EditorWindow gameViewWindow = 
//                    EditorWindowExtensions.GetGameViewWindow();

//                return gameViewWindow.GetRect();
//#elif UNITY_STANDALONE_WIN
//                // Grab the position and size of the standalone player's
//                // window when running a standalone build.
//                int x = 0;
//                int y = 0;
//                ZPlugin.GetWindowPosition(out x, out y);

//                return new RectInt(x, y, Screen.width, Screen.height);
//#else
//                return new RectInt(0, 0, Screen.width, Screen.height);
//#endif
            }
        }

        /// <summary>
        /// The size in pixels of the application window.
        /// </summary>
        /// 
        /// <remarks>
        /// When running from the Unity Editor, the size corresponds 
        /// to the Game View window.
        /// </remarks>
        public static Vector2Int Size
        {
            get
            {
#if UNITY_EDITOR
                return Rect.size;
#else
                return new Vector2Int(1920, 1080);
#endif
            }
        }
```

2. VirtualCameraStandard.cs文件中134行起
``` c#
// Get the current viewport size.
//UInt16 imageWidth = (UInt16)Screen.currentResolution.width;
//UInt16 imageHeight = (UInt16)Screen.currentResolution.height;
// dx:统一1920x1080
UInt16 imageWidth = 1920;
UInt16 imageHeight = 1080;
```