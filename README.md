# Documentation of the unit's 

## Solution explanation

## Objective of the work:

The objective of the exercise was to create an interactive application using Python with a pose classifier and a half pipe for hand detection in the system, to then communicate with Unity and be able to send it information to create a customized experience, in this case to make a 5 combinacion Rock, paper and scissors.

## Mathematical concepts:

The particles were used in 2 scenarios:

1. Execute the main, taking into account that it is executed in the same folder called classifier, where it has the coordinates of the poses of the combinations and the code for detecting the hands, the main(1) is executed and it is verified that everything is working: you can see it when doing poses with your hand and a red text at the top will say what pose it is.

```python
print(disp.confusion_matrix)

# Video Capture
while cap.isOpened():
    ret, frame = cap.read()
    if not ret:
        continue
    hand_landmarks = process_frame(frame)
    flip = cv2.flip(frame, 1)
    if hand_landmarks is not None:
        # Process the hand landmarks
        landmarks = [lmk for lmk in hand_landmarks]  # Extract all landmarks
        landmarks_array = np.zeros((21, 2), dtype=np.float32)
        for i, lmk in enumerate(landmarks):
            landmarks_array[i] = [lmk.x, lmk.y]
        landmarks_array = landmarks_array.flatten()  # Flatten to a 1D array

        # Print the x and y coordinates of each landmark
        x_coordinates = landmarks_array[::2]
        y_coordinates = landmarks_array[1::2]
        #print("X Coordinates:", x_coordinates)
        #print("Y Coordinates:", y_coordinates)

        # Embed the hand landmarks
        hand_embedding = pose_embedder(landmarks_array)
        # Preprocess the data
        hand_embedding = scaler.transform([hand_embedding])
        # Predict using the classifier
        predicted_class = classifier.predict(hand_embedding)
        # Draw the predicted class on the frame
        
        data_str = f"{predicted_class[0]};{';'.join([','.join(map(str, [lmk.x, lmk.y])) for lmk in landmarks])}"
        sock.sendto(data_str.encode(), serverAddressPort)

        cv2.putText(flip, f'Predicted: {label_encoder.classes_[predicted_class[0]]}', (10, 30),
                    cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 0, 255), 2)
```
2. Open Unity and Play, if this doest work please check the UDP port and address that the Python code its sending the data:
```c#

    private void ReceiveData()
    {
        client = new UdpClient(port);
        while (startReceiving)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref anyIP);
                data = Encoding.UTF8.GetString(dataByte);

                string[] dataParts = data.Split(';');
                if (dataParts.Length > 0)
                {
                    if (int.TryParse(dataParts[0], out firstNumber))
                    {
                        if (printToConsole) { print(data); }
                        // lo posemos borrar en caso de solucionar el HandTraking
                    }
                }
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

```
Extra Info: Maybe it is easy to send information by udp but using it in the style of sending coordinates and replicating them within a virtual environment is another story, it was originally intended to show the hand sending the coordinates of the 21 landmarks but the plan could not be carried out since unity was unable to process the information sent by the array of x,y and z coordinates
