namespace Domain {
    using System;


    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Messages {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }

        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Domain.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Recurso repetido campo: {0} Valor: {1}.
        /// </summary>
        public static string AlredyExistException {
            get {
                return ResourceManager.GetString("AlredyExistException", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to La entidad no puede ser null.
        /// </summary>
        public static string EntityCannotBeNull {
            get {
                return ResourceManager.GetString("EntityCannotBeNull", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to El Id proporcionado en la ruta no coincide con el Id en el cuerpo de la solicitud.
        /// </summary>
        public static string IdMismatchException {
            get {
                return ResourceManager.GetString("IdMismatchException", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to El correo no es valido.
        /// </summary>
        public static string InvalidEmailException {
            get {
                return ResourceManager.GetString("InvalidEmailException", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to El host entrante no es valido.
        /// </summary>
        public static string InvalidHostException {
            get {
                return ResourceManager.GetString("InvalidHostException", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to No se encontro el recurso {0}.
        /// </summary>
        public static string ResourceNotFoundException {
            get {
                return ResourceManager.GetString("ResourceNotFoundException", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to No se encontro el recurso {0}.
        /// </summary>
        public static string BadRequestException {
            get {
                return ResourceManager.GetString("BadRequestException", resourceCulture);
            }
        }

        /// <summary>
        ///   La cantidad de qr a asociar al contenido no esta disponible
        /// </summary>
        public static string AmountToAssociateContentException {
            get {
                return ResourceManager.GetString("AmountToAssociateContentException", resourceCulture);
            }
        }
    }
}
