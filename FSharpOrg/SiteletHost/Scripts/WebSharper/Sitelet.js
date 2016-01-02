(function()
{
 var Global=this,Runtime=this.IntelliFactory.Runtime,WebSharper,Piglets,Piglet1,Sitelet,Login,Client,Concurrency,Remoting,window,alert,LoginInfo,Pervasives,Validation,Html,Operators,Default,List,Controls,HTML5,jQuery,EventsPervasives,News,OperatorIntrinsics,Arrays,Shuffle,T,IntrinsicFunctionProxy,Math,Number;
 Runtime.Define(Global,{
  Sitelet:{
   Login:{
    Client:{
     form:function(redirectUrl)
     {
      return Piglet1.Render(function(name)
      {
       return function(password)
       {
        return function(submit)
        {
         return Client.loginRender(name,password,submit);
        };
       };
      },Piglet1.Run(function(loginInfo)
      {
       return Concurrency.Start(Concurrency.Delay(function()
       {
        return Concurrency.Bind(Remoting.Async("Sitelet:0",[loginInfo]),function(arg101)
        {
         if(arg101.$==1)
          {
           window.location.assign(redirectUrl);
           return Concurrency.Return(null);
          }
         else
          {
           alert("Login failed");
           return Concurrency.Return(null);
          }
        });
       }));
      },Client.loginPiglet(Runtime.New(LoginInfo,{
       Username:"",
       Password:""
      }))));
     },
     loginPiglet:function(init)
     {
      return Piglet1.WithSubmit(Pervasives.op_LessMultiplyGreater(Pervasives.op_LessMultiplyGreater(Piglet1.Return(function(username)
      {
       return function(password)
       {
        return LoginInfo.New(username,password);
       };
      }),Validation.Is(function(value)
      {
       return Validation.NotEmpty(value);
      },"Please enter your username.",Piglet1.Yield(init.Username))),Validation.Is(function(value)
      {
       return Validation.NotEmpty(value);
      },"Please enter your password.",Piglet1.Yield(init.Password))));
     },
     loginRender:function(name,password,submit)
     {
      var x1,arg00;
      x1=Operators.add(Controls.input("text",function(x)
      {
       return x;
      },function(x)
      {
       return x;
      },password),List.ofArray([Default.Attr().Class("form-control"),Default.Attr().NewAttr("type","password"),HTML5.Attr().NewAttr("placeholder","Password")]));
      arg00=function()
      {
       return function(keyCode)
       {
        return keyCode.KeyCode===13?jQuery("#submit-btn").click():null;
       };
      };
      EventsPervasives.Events().OnKeyDown(arg00,x1);
      return Operators.add(Default.Div(List.ofArray([Default.Attr().Class("well"),Default.Attr().NewAttr("id","login-form")])),List.ofArray([Operators.add(Default.Div(List.ofArray([Default.Attr().Class("form-group")])),List.ofArray([Operators.add(Controls.input("text",function(x)
      {
       return x;
      },function(x)
      {
       return x;
      },name),List.ofArray([Default.Attr().Class("form-control"),Default.Attr().NewAttr("type","text"),HTML5.Attr().NewAttr("autofocus","autofocus"),HTML5.Attr().NewAttr("required","required"),HTML5.Attr().NewAttr("placeholder","Username")]))])),Operators.add(Default.Div(List.ofArray([Default.Attr().Class("form-group")])),List.ofArray([x1])),Operators.add(Controls.SubmitValidate(submit),List.ofArray([Default.Attr().Class("btn btn-primary"),Default.Attr().NewAttr("id","submit-btn")]))]));
     }
    },
    Control:Runtime.Class({
     get_Body:function()
     {
      return Client.form(this.redirectUrl);
     }
    }),
    LoginInfo:Runtime.Class({},{
     New:function(username,password)
     {
      return Runtime.New(LoginInfo,{
       Username:username,
       Password:password
      });
     }
    })
   },
   News:{
    Control:Runtime.Class({
     get_Body:function()
     {
      return News.main();
     }
    }),
    main:Runtime.Field(function()
    {
     var _ul_43_1;
     _ul_43_1=Default.UL(List.ofArray([Default.Attr().Class("list-group wow animated fadeIn"),Default.Attr().NewAttr("id","news-list")]));
     jQuery.getJSON("http://ajax.googleapis.com/ajax/services/feed/load?v=1.0&num=10&callback=?&q=http%3A%2F%2Ffpish.net%2Frss%2Fblogs%2Ftag%2F1%2Ff~23",Runtime.Tupled(function(tupledArg)
     {
      var data,_arg1,entries,x;
      data=tupledArg[0];
      _arg1=tupledArg[1];
      entries=data.responseData.feed.entries;
      x=OperatorIntrinsics.GetArraySlice(entries,{
       $:0
      },{
       $:1,
       $0:4
      });
      return Arrays.iter(function(x1)
      {
       var arg10;
       arg10=x1.link;
       return _ul_43_1.AppendI(Operators.add(Default.LI(List.ofArray([Default.Attr().Class("list-group-item")])),List.ofArray([Operators.add(Default.H4(List.ofArray([Default.Attr().Class("list-group-item-heading")])),List.ofArray([Default.A(List.ofArray([Default.Attr().NewAttr("href",arg10),Default.Attr().NewAttr("target","_blank"),Default.Text(x1.title)]))])),Default.P(List.ofArray([Default.Text(x1.contentSnippet)]))])));
      },x);
     }));
     return _ul_43_1;
    })
   },
   Shuffle:{
    Control:Runtime.Class({
     get_Body:function()
     {
      return Shuffle.main();
     }
    }),
    main:function()
    {
     var x;
     x=Default.Div(Runtime.New(T,{
      $:0
     }));
     Operators.OnAfterRender(function()
     {
      var array,x1,srcs,array1;
      array=jQuery(".carousel-link").toArray();
      x1=Shuffle.shuffle(array);
      srcs=Arrays.map(function(elt)
      {
       return[elt.getAttribute("href"),jQuery(".carousel-img",elt).attr("src")];
      },x1);
      array1=Arrays.zip(srcs,jQuery(".carousel-link").toArray());
      Arrays.iter(Runtime.Tupled(function(tupledArg)
      {
       var _arg1,elt,src;
       _arg1=tupledArg[0];
       elt=tupledArg[1];
       src=_arg1[1];
       elt.setAttribute("href",_arg1[0]);
       return jQuery(".carousel-img",elt).attr("src",src);
      }),array1);
      jQuery.getJSON("testimonials.json",Runtime.Tupled(function(tupledArg)
      {
       var json,_arg2,arr,x2,x3,jq1,jq2;
       json=tupledArg[0];
       _arg2=tupledArg[1];
       arr=Shuffle.shuffle(json);
       x2=OperatorIntrinsics.GetArraySlice(arr,{
        $:0
       },{
        $:1,
        $0:5
       });
       x3=Arrays.map(function(x4)
       {
        var arg10,arg101;
        arg101=List.ofArray([Default.A(List.ofArray([Default.HRef(x4.Permalink),Default.Text(x4.Author)]))]);
        arg10=List.ofArray([Default.P(List.ofArray([Default.A(List.ofArray([Default.HRef(x4.Permalink),Default.Attr().Class("testimonial"),Default.Text(x4.Text)]))])),HTML5.Tags().NewTag("footer",List.ofArray([Default.Tags().NewTag("cite",arg101)]))]);
        return Default.Tags().NewTag("blockquote",arg10);
       },x2);
       jq1=jQuery("#testimonials-col-1").empty();
       Arrays.iter(function(elt)
       {
        jq1.append(elt.Body);
       },OperatorIntrinsics.GetArraySlice(x3,{
        $:0
       },{
        $:1,
        $0:2
       }));
       jq2=jQuery("#testimonials-col-2").empty();
       return Arrays.iter(function(elt)
       {
        jq2.append(elt.Body);
       },OperatorIntrinsics.GetArraySlice(x3,{
        $:1,
        $0:3
       },{
        $:0
       }));
      }));
      return;
     },x);
     return x;
    },
    shuffle:function(array)
    {
     var currentIndex,randomIndex,temporaryValue;
     currentIndex={
      contents:IntrinsicFunctionProxy.GetLength(array)
     };
     while(currentIndex.contents!==0)
      {
       randomIndex=Math.floor(Math.random()*Number(currentIndex.contents));
       currentIndex.contents=currentIndex.contents-1;
       temporaryValue=array[currentIndex.contents];
       array[currentIndex.contents]=array[randomIndex];
       array[randomIndex]=temporaryValue;
      }
     return array;
    }
   }
  }
 });
 Runtime.OnInit(function()
 {
  WebSharper=Runtime.Safe(Global.IntelliFactory.WebSharper);
  Piglets=Runtime.Safe(WebSharper.Piglets);
  Piglet1=Runtime.Safe(Piglets.Piglet1);
  Sitelet=Runtime.Safe(Global.Sitelet);
  Login=Runtime.Safe(Sitelet.Login);
  Client=Runtime.Safe(Login.Client);
  Concurrency=Runtime.Safe(WebSharper.Concurrency);
  Remoting=Runtime.Safe(WebSharper.Remoting);
  window=Runtime.Safe(Global.window);
  alert=Runtime.Safe(Global.alert);
  LoginInfo=Runtime.Safe(Login.LoginInfo);
  Pervasives=Runtime.Safe(Piglets.Pervasives);
  Validation=Runtime.Safe(Piglet1.Validation);
  Html=Runtime.Safe(WebSharper.Html);
  Operators=Runtime.Safe(Html.Operators);
  Default=Runtime.Safe(Html.Default);
  List=Runtime.Safe(WebSharper.List);
  Controls=Runtime.Safe(Piglets.Controls);
  HTML5=Runtime.Safe(Default.HTML5);
  jQuery=Runtime.Safe(Global.jQuery);
  EventsPervasives=Runtime.Safe(Html.EventsPervasives);
  News=Runtime.Safe(Sitelet.News);
  OperatorIntrinsics=Runtime.Safe(WebSharper.OperatorIntrinsics);
  Arrays=Runtime.Safe(WebSharper.Arrays);
  Shuffle=Runtime.Safe(Sitelet.Shuffle);
  T=Runtime.Safe(List.T);
  IntrinsicFunctionProxy=Runtime.Safe(WebSharper.IntrinsicFunctionProxy);
  Math=Runtime.Safe(Global.Math);
  return Number=Runtime.Safe(Global.Number);
 });
 Runtime.OnLoad(function()
 {
  News.main();
  return;
 });
}());
