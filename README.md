# shootin-cupid-echo3D-unity-demo
A Valentine's Game Demo for echo3D and Unity

## Register
Don't have an API key? Make sure to register for FREE at [echo3D](https://console.echo3D.co/#/auth/register).

## Setup
* Clone the [shootin-cupid-echo3D-unity-demo](https://github.com/yuval-krn/shootin-cupid-echo3D-unity-demo).

### Echo API Setup
* [Set the API key](https://docs.echo3D.co/unity/using-the-sdk) in the `echoAR.cs` script inside the `echoAR\echoAR.prefab` using the the Inspector.
* [Add the 3D model](https://docs.echo3D.co/quickstart/add-a-3d-model) from the 'Models' folder to the console in corresponding scenes. 
* Each folder in the Models folder should be a new project (API key) in your echo3D console.
* If a model does not have a corresponding CSV file, it means that there is no metadata to input for that model. Hence, you can skip adding any metadata to that model. Otherwise, copy the metadata from each model's corresponding CSV file in the folder. 
* We recommend to add videos and audios from `Models\VideosAudios` to a seperate key [Load a Key](https://docs.echo3D.co/web-console/load-a-key).
* Set the Video API key inside the `Prefabs\echoAR (video).prefab` using the the Inspector.
* [Add the corresponding metadata](https://docs.echo3D.co/web-console/manage-pages/data-page/how-to-add-data#adding-metadata) listed in the `Models` folder.
* For videos and audios project, make sure all models' metadata have a "Index" key with a special non-negative integer value.

## Learn more
Refer to our [documentation](https://docs.echo3D.co/unity/) to learn more about how to use Unity and echo3D.

## Support
Feel free to reach out at [support@echo3D.co](mailto:support@echo3D.co) or join our [support channel on Slack](https://go.echo3D.co/join).

##Screenshots
