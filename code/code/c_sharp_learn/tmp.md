## 手动释放new 对象的内存
1. 对象Dispose()方法：对象实现IDisposable接口，可以重写Dispose()方法释放资源，调用Dispose()方法可以手动释放资源。举例：
```csharp
FileStream fs = new FileStream("文件路径", FileMode.Open);
using(fs){
//code
}
```

2. 数组元素赋值为null：将数组元素赋值为null，可以手动释放内存。举例：

```csharp
int[] arr = new int[]{1,2,3,4,5};
arr = null;
```

3.GC.Collect()方法：强制回收内存，但使用该方法会影响性能，不建议频繁使用。举例：
```csharp
GC.Collect();
```


4.使用using语句块：将需要手动释放的对象放在using语句块中，离开using范围后自动调用Dispose方法释放资源。举例：
```csharp
using(StreamReader sr = new StreamReader("文件路径")){
//code
}
```

5.手动调用Dispose()方法释放资源。举例：
```csharp
MemoryStream ms = new MemoryStream();
//code
ms.Dispose();
ms = null;
```