package com.example.andrew.app1;

import android.graphics.Interpolator;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;
import android.content.Context;

import android.app.Activity;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.SocketTimeoutException;
import java.net.URL;
import android.util.Log;



public class MainActivity extends AppCompatActivity {

    Button loginB;
    EditText et1, et2;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        loginB = (Button)findViewById(R.id.button1);
        et1 = (EditText) findViewById(R.id.editText1);
        et2 = (EditText) findViewById(R.id.editText2);

        loginB.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                // Toast.makeText(getApplicationContext(), et1.getText().toString(), Toast.LENGTH_SHORT).show();

                String username = et1.getText().toString();
                String password = et2.getText().toString();

                AsyncPost newPost = new AsyncPost();
                newPost.TaskinBack(MainActivity.this);
                newPost.execute(username,password);



            }
        });
    }
}

class AsyncPost extends AsyncTask<String, Void, Void>{
    int accepted = 0;
    private Context mContext;

    public void TaskinBack(Context context){
        this.mContext = context;
    }
    @Override
    protected void onPostExecute(Void result){
        if(accepted == 1){
            Toast.makeText(mContext, "Redirecting...",Toast.LENGTH_SHORT).show();
        }else{
            Toast.makeText(mContext, "Incorrect Login",Toast.LENGTH_SHORT).show();
        }
    }
    @Override
    protected Void doInBackground(String... params){
        try {
            URL url = new URL("http://www.foodusedb.com/home/PHP/loginAndroid.php");
            HttpURLConnection client = (HttpURLConnection) url.openConnection();

            String urlParameters = "ID="+params[0]+"&Password="+params[1];
            byte[] postData = urlParameters.getBytes( "UTF-8");
            int postDataLength = postData.length;

            client.setRequestMethod("POST");
            client.setRequestProperty( "Content-Type", "application/x-www-form-urlencoded");
            client.setRequestProperty( "charset", "utf-8");
            client.setRequestProperty( "Content-Length", Integer.toString( postDataLength ));
            client.setDoOutput(true);
            client.setDoInput(true);

            Log.d("params:", params[0] + " " + params[1]);



            DataOutputStream outputPost = new DataOutputStream(client.getOutputStream());
            outputPost.write(postData);


            InputStream in = new BufferedInputStream((client.getInputStream()));
            byte[] contents = new byte[1024];

            int bytesRead;
            String strFileContents = "";
            while((bytesRead = in.read(contents)) != -1) {
                strFileContents += new String(contents, 0, bytesRead);
            }

            JSONObject response;
            response = new JSONObject(strFileContents);

            Log.d("Output",strFileContents);
            Log.d("JSON", response.toString());
            Log.d("val", Integer.toString(response.getInt("Valid")));
            accepted = response.getInt("Valid");

            outputPost.flush();
            outputPost.close();

        } catch (MalformedURLException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return null;
    }


}