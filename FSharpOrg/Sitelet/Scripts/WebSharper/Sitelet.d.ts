declare module Sitelet {
    module Site {
        interface Website {
        }
    }
    module Shuffle {
        interface Testimonial {
            Permalink: string;
            Text: string;
            Link: string;
            Author: string;
        }
        interface Control {
            get_Body(): __ABBREV.__Html.IPagelet;
        }
        var shuffle : {
            <_M1>(array: _M1[]): _M1[];
        };
        var main : {
            (): __ABBREV.__Html.Element;
        };
    }
    module News {
        interface Response {
            responseData: any;
        }
        interface data {
            feed: any;
        }
        interface feedDetails {
            entries: any[];
        }
        interface Entry {
            title: string;
            link: string;
            contentSnippet: string;
        }
        interface Control {
            get_Body(): __ABBREV.__Html.IPagelet;
        }
        var main : {
            (): __ABBREV.__Html.Element;
        };
    }
    module Model {
        interface Action {
        }
    }
    module Login {
        module LoginInfo {
            var New : {
                (username: string, password: string): __ABBREV.__Login.LoginInfo;
            };
        }
        module Client {
            var loginPiglet : {
                <_M1>(init: __ABBREV.__Login.LoginInfo): __ABBREV.__Piglets.Piglet<__ABBREV.__Login.LoginInfo, {
                    (x: {
                        (x: __ABBREV.__Piglets.Stream<string>): {
                            (x: __ABBREV.__Piglets.Stream<string>): {
                                (x: __ABBREV.__Piglets.Submitter<__ABBREV.__Login.LoginInfo>): _M1;
                            };
                        };
                    }): _M1;
                }>;
            };
            var loginRender : {
                <_M1>(name: __ABBREV.__Piglets.Stream<string>, password: __ABBREV.__Piglets.Stream<string>, submit: __ABBREV.__Piglets.Submitter<_M1>): __ABBREV.__Html.Element;
            };
            var form : {
                (redirectUrl: string): __ABBREV.__Html.Element;
            };
        }
        interface LoginInfo {
            Username: string;
            Password: string;
        }
        interface Access {
        }
        interface Control {
            get_Body(): __ABBREV.__Html.IPagelet;
        }
    }
    module Skin {
        interface Page {
            MetaDescription: string;
            Title: string;
            Nav: any;
            Body: any;
        }
    }
}
declare module __ABBREV {
    
    export import __Html = IntelliFactory.WebSharper.Html;
    export import __Login = Sitelet.Login;
    export import __Piglets = IntelliFactory.WebSharper.Piglets;
}
