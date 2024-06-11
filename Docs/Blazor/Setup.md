# Setup PCA Pattern for Server Side Blazor
In this section we will outline how to setup a blazor server side project to use the PCA pattern.

## Configuring Program.cs
In the program.cs file we need to register two global services that are used for central management of notification and dialogs in the application.

Add the following statement before the builder creates the app. So basically before this line **var app = builder.Build();**
```
builder.Services.AddPCAServices();
```


## Setup Central Notification and Dialog Management 
In the PCA framework there is support to host a central notifcation and dialog support. To do this you update your layout to host the components the execute the central management. Currently we have an example for telerik based components implemented. 

Bellow is a code example of the components implemented in a layout. The components **TelerikCentralNotification** and **TelerikCentralDialog** are added just before the body definition is implemented. 

```
@using CodeFactory.PCA.Blazor.Tel
@inherits LayoutComponentBase
<TelerikRootComponent>
<div class="page">
    <div class="sidebar">
        <NavMenu />
    </div>

    <main>
        <div class="top-row px-4">
            <a href="https://learn.microsoft.com/aspnet/core/" target="_blank">About</a>
        </div>
        <TelerikCentralNotification HorizontalPosition="NotificationHorizontalPosition.Center" VerticalPosition="NotificationVerticalPosition.Bottom"/>
        <TelerikCentralDialog/>
        <article class="content px-4">
            @Body
        </article>
    </main>
</div>

<div id="blazor-error-ui">
    An unhandled error has occurred.
    <a href="" class="reload">Reload</a>
    <a class="dismiss">🗙</a>
</div>

</TelerikRootComponent>
```

[Return to PCA for Server Side Blazor](/Docs/Blazor/Readme.md)
