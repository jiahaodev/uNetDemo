# uNetDemo

unity Multiplayer and Networking 的Demo

参考的教程为：

第一节：
[unity官方内置网络unet的实例教程（一）](https://www.jianshu.com/p/d4e35e547081)

第二节：https://www.jianshu.com/p/d7481e83317c

第三节：https://www.jianshu.com/p/f33af7106db1

第四节：https://www.jianshu.com/p/5b211f3f4ec6 

第五节：https://www.jianshu.com/p/cb034b4c317d 

第六节：https://www.jianshu.com/p/c58c1a888595 

第七节：https://www.jianshu.com/p/b8cc2d15e2b5

第八节：https://www.jianshu.com/p/9f8f18a46266


特殊说明：
这个例子已经涵盖了制作简单的多人网络游戏所需的大部分基本概念和组件，使用了

* [Command]：客户端调用服务端执行 、 【其实可以不用】
* [ClientRpc]：服务端调用客户端执行、【其实可以不用】
* [SyncVar]：让变量同步、           【其实可以不用】
* SyncVar hooks同步变量值变化时调用被Hook的函数、【其实可以不用】
* NetworkIdentity具有网络注册识别、
* NetworkTransform同步变幻的同步功能、
* NetworkStartPosition生成位置、
* NetworkManager网络管理等这些概念。

其中，前4个可以不用的原因，可能是 uNet 升级后，已经直接通过管理“Player”这个级别的  数据变化 及 自动同步，不再需要开发者自行设置。