# Presentation Control Abstraction for Server Side Blazor
This is the core library for the PCA for server side Blazor pattern. 
The core focus of this library is clean separation of concerns between a Blazor component and control and flow logic that accesses external resources. 

This library implements the following. 
- Presentation base class for Blazor UI functionality
- Controller base class for implementation of control and flow functionality to manage a target Blazor component. 
- Status edit form is a extended edit form that exposes when data has changed within the scope of an edit form.
- Navigation management to block navigation when data has changed. Implemented on the controller to support navigation manager, and browser based alerting. 
- Centralized notification service allows for all notification or **Toasts** to render directly on layout.
- Centralized dialog service allows for all dialogs to render directly on the layout. 
