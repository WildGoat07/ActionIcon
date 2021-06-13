# ActionIcon

ActionIcon is a very small library with a single custom WPF Control : `ActionIcon`. It uses an icon image source and can add onto it small modifiers like the 'add' modifier, or 'edit' for example.

[Nuget package](https://www.nuget.org/packages/ActionIcon).

## Example

Consider the file "Document_16x.png" ![Document_16x.png](https://user-images.githubusercontent.com/30344403/121817128-b08ee600-cc7f-11eb-9aaf-0da7342aba86.png) a resource of the project.

The most basic use is the following :

```xml
<ai:ActionIcon
    VerticalAlignment="Center"
    HorizontalAlignment="Center"
    BaseSource="/Document_16x.png" />
```

Which simply outputs : ![image](https://user-images.githubusercontent.com/30344403/121817158-ecc24680-cc7f-11eb-99ea-f68edd734d6a.png)

Now let's add some modifiers :

```xml
<ai:ActionIcon
    VerticalAlignment="Center"
    HorizontalAlignment="Center"
    BaseSource="/Document_16x.png"
    Action="NEW" />
```

Boom we got a "new document" icon : ![image](https://user-images.githubusercontent.com/30344403/121817225-58a4af00-cc80-11eb-94cf-6436d8a9dc1d.png)

And you can combine anything you want, but just keep it simple enough to be understandable :

```xml
<ai:ActionIcon
    VerticalAlignment="Center"
    HorizontalAlignment="Center"
    BaseSource="/Document_16x.png"
    Action="ADD"
    Status="SYNC" />
```

Output : ![image](https://user-images.githubusercontent.com/30344403/121817263-8be73e00-cc80-11eb-8b54-c84b725cc776.png)

Finally, you can obviously use your own icon modifiers using `ActionSource`, `StatusSource` or `ModifierSource` (just note that if these properties are different than `null`, `Action`, `Status` and `Modifier` will respectively be ignored) :

```xml
<ai:ActionIcon
    VerticalAlignment="Center"
    HorizontalAlignment="Center"
    BaseSource="/Document_16x.png"
    ModifierSource="/Property_overlay_8x_16x.png" />
```

Output : ![image](https://user-images.githubusercontent.com/30344403/121817311-e41e4000-cc80-11eb-9c3c-6c606ef734d3.png)

