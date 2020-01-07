package com.example.twitter20;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;

import com.example.twitter20.ui.Messages.MessagesFragment;
import com.example.twitter20.ui.home.HomeFragment;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.android.material.snackbar.Snackbar;

import android.view.View;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.ui.AppBarConfiguration;
import androidx.navigation.ui.NavigationUI;

import com.google.android.material.navigation.NavigationView;
import com.google.android.material.tabs.TabLayout;

import androidx.drawerlayout.widget.DrawerLayout;

import androidx.appcompat.app.AppCompatActivity;
import androidx.viewpager.widget.ViewPager;

import android.view.Menu;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.Toolbar;

import java.util.Arrays;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    Button btnHome;
    Button btnSearch;
    Button btnNotification;
    Button btnMessage;
    Button btnPP;
    FloatingActionButton twitButton;
    TabLayout tabLayout;
    Toolbar toolbar;
    ViewPager viewPager;
    Context context = this;
    private AppBarConfiguration mAppBarConfiguration;
//    MessagesFragment messageFragment = new MessagesFragment();
//    HomeFragment homeFragment = new HomeFragment();
//    FragmentManager fragmentManager = getSupportFragmentManager();
//    FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        btnHome = findViewById(R.id.btn_home);
        btnSearch = findViewById(R.id.btn_search);


        btnNotification = findViewById(R.id.btn_notification);
        btnMessage = findViewById(R.id.btn_messages);


        btnHome.setOnClickListener(new View.OnClickListener() {
            FragmentManager fragmentManager = getSupportFragmentManager();
            FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
            HomeFragment homeFragment = new HomeFragment();
            @Override
            public void onClick(View view) {
                for (Fragment fragment : getSupportFragmentManager().getFragments()) {
                    if (fragment != null) {
                        getSupportFragmentManager().beginTransaction().detach(fragment).commit();
                    }
                }
                fragmentTransaction.replace(R.id.appBarLayout, homeFragment);
                fragmentTransaction.commit();

            }
        });


        btnMessage.setOnClickListener(new View.OnClickListener() {
            FragmentManager fragmentManager = getSupportFragmentManager();
            FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
            MessagesFragment messageFragment = new MessagesFragment();
            @Override
            public void onClick(View view) {

                for (Fragment fragment : getSupportFragmentManager().getFragments()) {
                    if (fragment != null) {
                        getSupportFragmentManager().beginTransaction().detach(fragment).commit();
                    }
                }
                fragmentTransaction.replace(R.id.appBarLayout, messageFragment);
                fragmentTransaction.commit();
            }
        });
//
//        btnNotification.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View view) {
//                NotificationFragment homeFragment = new NotificationFragment();
//                FragmentManager fragmentManager = getSupportFragmentManager();
//                FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
//                fragmentTransaction.replace(R.id.mainConstraint,homeFragment,"notification");
//                fragmentTransaction.commit();
//            }
//        });

//        btnSearch.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View view) {
//                Toast.makeText(getApplicationContext(),"tıklandı search",Toast.LENGTH_SHORT).show();
//                SearchFragment searchFragment = new SearchFragment();
//
//                FragmentManager fragmentManager = getSupportFragmentManager();
//                FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
//                fragmentTransaction.replace(R.id.mainConstraint,searchFragment,"search");
//                fragmentTransaction.commit();
//            }
//        });

    }
}
