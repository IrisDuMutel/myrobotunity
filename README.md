# myrobot_unity

This project contains the model and scripts for the simulation of a two-wheeled robot whithin the Unity environment.

This branch is destined to the training of a robot that spawns and moves objects around the scene depending on what he is told. A camera is supposed to send images through an object detection NN and come out with the unity input to populate the scene.

The robot can be moved using the arros or wasd convention when using the diff_drive script. The camera controller can be disabled anytime by removign the tick to the script in 'MainCamera'.



## ROS communication
 In this project, two packages for ROS communication-compatibility are used:

 - [URDF Importer](https://github.com/Unity-Technologies/URDF-Importer.git#v0.1.2)
 - [TCP-ROS Connection](https://github.com/Unity-Technologies/ROS-TCP-Connector.git#v0.1.2)
 - [TCP Endpoint](https://github.com/Unity-Technologies/ROS-TCP-Endpoint.git)

URDF importer enables the use of URDF models in Unity. TCP-ROS Connection manages the communication between Unity and ROS.

To use the second package, it is necessary to clone robotics demo by:

`git clone https://github.com/Unity-Technologies/Unity-Robotics-Hub/tree/dev/tutorials/ros_packages/robotics_demo`

Also, TCP Endpoint must be cloned:

`git clone https://github.com/Unity-Technologies/ROS-TCP-Endpoint.git`

 This must be done inside a ROS workspace (inside the src folder) as a it needs to be built as a ROS package throughout 'catkin_make'.

 Build your catkin workspace. Then, open you Unity project and attach the first two packages to Unity via:

    Window -> Package Manager -> Add package from git URL

Once attached, go to Robotics -> ROS Settings and fill the two fields as:

| Field | Value |
| ----------- | ----------- |
| ROS IP Address | ip address from ROS machine |
| ROS Port | 10000 | 

Then, go to Robotics -> Generate ROS Messages and choose the robotics_demo/msg folder as the ROS message path and generate the messages. 

Create a *config* folder and inside, create a *params.yaml* empty file and write:

> fill with your own ROS_IP

    ROS_IP: 192.168.0.109 
    ROS_TCP_PORT: 10000


 To start ROS-Unity communication:

    - Start a rosmaster: 'roscore'
    - Load param.yaml file: 'rosparam load PATH/TO/robotics_demo/config/params.yaml'
    - Run the server_endpoint.py node: 'rosrun robotics_demo server_endpoint.py'
  
For further information, go to 'https://github.com/Unity-Technologies/Unity-Robotics-Hub/tree/dev'


General view of the scene:
![alt text](https://github.com/IrisDuMutel/myrobotunity/blob/mydreams/Screenshot%20from%202021-05-14%2017-23-46.png?raw=true )

